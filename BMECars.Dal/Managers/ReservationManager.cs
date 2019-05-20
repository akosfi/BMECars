using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public class ReservationManager : IReservationManager
    {
        BMECarsDbContext _context;
        UserManager<User> userManager;

        ICarManager carManager;
        ILocationManager locationManager;
        ICompanyManager companyManager;
        readonly IHttpContextAccessor httpContextAccessor;

        public ReservationManager(
            BMECarsDbContext BMECarsDbContext, 
            ICarManager _carManager, 
            ILocationManager _locationManager,
            ICompanyManager _companyManager,
            UserManager<User> _userManager,
            IHttpContextAccessor _httpContextAccessor
        )
        {
            _context = BMECarsDbContext;
            carManager = _carManager;
            locationManager = _locationManager;
            userManager = _userManager;
            companyManager = _companyManager;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task MakeReservation(PaymentDTO car)
        {
            LocationDTO pickUpLocation = await locationManager.GetLocation(car.PickUpLocationId);
            LocationDTO dropDownLocation = await locationManager.GetLocation(car.DropDownLocationId);
            SearchDTO selectedCar = new SearchDTO
            {
                Id = car.Id,
                ReserveFrom = car.ReserveFrom,
                ReserveTo = car.ReserveTo,
                CountryPickUp = pickUpLocation.Country,
                CityPickUp = pickUpLocation.City,
                LocationPickUp = pickUpLocation.Address,
                CountryDropDown = dropDownLocation.Country,
                CityDropDown = dropDownLocation.City,
                LocationDropDown = dropDownLocation.Address
            };
            List<int> avaibleCarIds = carManager.GetCars(selectedCar).Select(c => c.Id).ToList();
            
            //check if still available
            if (avaibleCarIds.Contains(car.Id))
            {
                string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                CarDTO originalCar = await carManager.GetCar(car.Id);
                await _context.AddAsync(new Reservation {
                    CarId = car.Id,
                    ReservationPrice = ((int)Math.Abs((car.ReserveFrom - car.ReserveTo).TotalDays) + 1) * originalCar.Price,
                    ReserveFrom = car.ReserveFrom,
                    ReserveTo = car.ReserveTo,
                    PickUpLocationId = pickUpLocation.Id,
                    DropDownLocationId = dropDownLocation.Id,
                    UserId = userId
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ReservationDTO>> GetPendingReservationsForCompany(int id)
        {
            List<ReservationDTO> pendingReservations 
                 = await _context.Reservations
                                 .Include(r => r.Car)
                                 .Where(r => r.Car.CompanyId == id && r.Accepted == ReservationStatus.Pending)
                                 .Select(r => new ReservationDTO {
                                     Id = r.Id,
                                     CarPlate = r.Car.Plate,
                                     Accepted = r.Accepted,
                                     CarId = r.CarId,
                                     DropDownLocation = r.DropDownLocation,
                                     PickUpLocation = r.PickUpLocation,
                                     ReservationPrice = r.ReservationPrice,
                                     ReserveFrom = r.ReserveFrom,
                                     ReserveTo = r.ReserveTo
                                 })
                                 .ToListAsync();


            foreach(ReservationDTO reservation in pendingReservations)
            {
                Reservation beforePendingReservation
                    = await _context.Reservations.Include(r => r.Car)
                                    .Where(r => r.CarId == reservation.CarId)
                                    .Where(r => reservation.ReserveFrom > r.ReserveTo)
                                    .OrderByDescending(r => r.ReserveTo)
                                    .FirstOrDefaultAsync();

                if (beforePendingReservation != null)
                {
                    reservation.PreviousReservationEnd = await _context.Reservations.Include(r => r.DropDownLocation)
                                                                                    .Where(r => r.Id == beforePendingReservation.Id)
                                                                                    .Select(r => r.DropDownLocation)
                                                                                    .FirstOrDefaultAsync();
                    reservation.PreviousReservationEndDate = beforePendingReservation.ReserveTo;
                }

                Reservation afterPendingReservation
                                    = await _context.Reservations.Include(r => r.Car)
                                                    .Where(r => r.CarId == reservation.CarId)
                                                    .Where(r => reservation.ReserveTo < r.ReserveFrom)
                                                    .OrderBy(r => r.ReserveFrom)
                                                    .FirstOrDefaultAsync();

                if (afterPendingReservation != null)
                {
                    reservation.NextReservationStart = await _context.Reservations.Include(r => r.PickUpLocation)
                                                                                    .Where(r => r.Id == afterPendingReservation.Id)
                                                                                    .Select(r => r.PickUpLocation)
                                                                                    .FirstOrDefaultAsync();
                    reservation.NextReservationStartDate = afterPendingReservation.ReserveFrom;
                }

            }

            return pendingReservations;
        }

        public async Task ApproveReservation(int id, bool approve = false)
        {
            Reservation reservation = await _context.Reservations
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefaultAsync();

            if (reservation == null) return;
            if (reservation.Accepted != ReservationStatus.Pending) return; //no undo

            int companyId = await _context.Reservations
                                          .Include(r => r.Car)
                                          .Where(r => r.Id == reservation.Id)
                                          .Select(r => r.Car.CompanyId)
                                          .FirstOrDefaultAsync();


            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool authorized = await companyManager.IsUserAdminAtCompany(userId, companyId);

            if (!authorized) return;

            if (approve)
            {
                reservation.Accepted = ReservationStatus.Accepted;
            }
            else
            {
                reservation.Accepted = ReservationStatus.Declined;
            }            

            await _context.SaveChangesAsync();
        }

        public async Task<List<ReservationDTO>> GetReservationsForUser(string userId)
        {
            return await _context.Reservations
                                       .Include(r => r.Car)
                                       .Include(r => r.PickUpLocation)
                                       .Include(r => r.DropDownLocation)
                                       .Where(r => r.UserId == userId)
                                       .Select(r => new ReservationDTO {
                                           Id = r.Id,
                                           CarId = r.CarId,
                                           CarPlate = r.Car.Plate,
                                           Accepted = r.Accepted,
                                           ReserveFrom = r.ReserveFrom,
                                           ReserveTo = r.ReserveTo,
                                           PickUpLocation = r.PickUpLocation,
                                           DropDownLocation = r.DropDownLocation
                                       })
                                       .ToListAsync();
        }

        public async Task<BillingDataDTO> GetBillingData(int id)
        {
            return await _context.BillingDatas
                                 .Where(bd => bd.Id == id)
                                 .Select(bd => new BillingDataDTO
                                 {
                                     Address = bd.Address,
                                     Id = bd.Id,
                                     Country = bd.Country,
                                     FirstName = bd.FirstName,
                                     LastName = bd.LastName,
                                     City = bd.City,
                                     Postal = bd.Postal,
                                     State = bd.State,
                                     Company = bd.Company
                                 })
                                 .FirstOrDefaultAsync();
        }

        public async Task AddBillingData(BillingDataDTO billingData)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _context.BillingDatas
                          .AddAsync(new BillingData {
                              UserId = userId,
                              Company = billingData.Company,
                              Address = billingData.Address,
                              City = billingData.City,
                              Country = billingData.Country,
                              FirstName = billingData.FirstName,
                              LastName = billingData.LastName,
                              Postal = billingData.Postal,
                              State = billingData.State
                          });
            await _context.SaveChangesAsync();
        }

        public async Task<List<BillingDataDTO>> GetBillingDatasForUser(string userId)
        {
            return await _context.BillingDatas
                          .Where(bd => bd.UserId == userId)
                          .Select(bd => new BillingDataDTO
                          {
                              Address = bd.Address,
                              City = bd.City,
                              Company = bd.Company,
                              Country = bd.Country,
                              FirstName = bd.FirstName,
                              LastName = bd.LastName,
                              Postal = bd.Postal,
                              State = bd.State,
                              Id = bd.Id
                          })
                          .ToListAsync();
        }

        public async Task<List<ReservationDTO>> GetReservationsForCar(int id)
        {
            return await _context.Reservations
                                 .Include(r => r.Car)
                                 .Include(r => r.DropDownLocation)
                                 .Include(r => r.PickUpLocation)
                                 .Where(r => r.CarId == id)
                                 .Select(r => new ReservationDTO {
                                     Accepted = r.Accepted,
                                     CarId = r.CarId,
                                     CarPlate = r.Car.Plate,
                                     DropDownLocation = r.DropDownLocation,
                                     PickUpLocation = r.PickUpLocation,
                                     Id = r.Id,
                                     ReserveFrom = r.ReserveFrom,
                                     ReserveTo = r.ReserveTo,
                                     ReservationPrice = r.ReservationPrice
                                 })
                                 .ToListAsync();
        }
    }
}
