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

        public async Task MakeReservation(SearchDTO car)
        {
            List<int> avaibleCarIds = carManager.GetCars(car).Select(c => c.Id).ToList();
            
            if (avaibleCarIds.Contains(car.Id))
            {
                string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                LocationDTO pickUpLocation = await locationManager.GetLocationByAddress(car.CountryPickUp, car.CityPickUp, car.LocationPickUp);
                LocationDTO dropDownLocation = await locationManager.GetLocationByAddress(car.CountryDropDown, car.CityDropDown, car.LocationDropDown);
                await _context.AddAsync(new Reservation {
                    CarId = car.Id,
                    ReservationPrice = car.Price,
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
            return await _context.Reservations
                                 .Include(r => r.Car)
                                 .Where(r => r.Car.CompanyId == id && r.Accepted == false)
                                 .Select(r => new ReservationDTO {
                                     Id = r.Id,
                                     Accepted = r.Accepted,
                                     CarId = r.CarId,
                                     DropDownLocation = r.DropDownLocation,
                                     PickUpLocation = r.PickUpLocation,
                                     ReservationPrice = r.ReservationPrice,
                                     ReserveFrom = r.ReserveFrom,
                                     ReserveTo = r.ReserveTo
                                 })
                                 .ToListAsync();
        }

        public async Task ApproveReservation(int id, bool approve = false)
        {
            Reservation reservation = await _context.Reservations
                                                    .Where(r => r.Id == id)
                                                    .FirstOrDefaultAsync();

            if (reservation == null) return;
            if (reservation.Accepted) return; //no undo

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
                reservation.Accepted = true;
            }
            else
            {
                _context.Reservations.Remove(reservation);
            }            

            await _context.SaveChangesAsync();
        }
    }
}
