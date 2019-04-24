using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public class CarManager : ICarManager
    {
        BMECarsDbContext _context;
        public CarManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
        }

        public CarHeaderDTO GetCarHeader(int id)
        {
            var car = _context.Cars.Select(c => new CarHeaderDTO
            {
                Id = c.Id,
                Brand = c.Brand,
                Price = c.Price
            }).SingleOrDefault(c => c.Id == id);
            return car;
        }

        public List<string> GetAvailableCarBrands()
        {
            return _context.Cars.Select(c => c.Brand).Distinct().ToList();
        }

        public async Task<List<string>> GetAllCarBrands()
        {
            using (var reader = File.OpenText("../BMECars.DAL/Static/CarBrandList.txt"))
            {
                var fileText = await reader.ReadToEndAsync();
                return fileText.Split('\n').Select(p => p.Trim()).ToList();
            }
        }

        public List<CarDTO> GetCarsForCompany(int companyId)
        {
            return _context.Cars
                .Where(c => c.CompanyId == companyId)
                .Select(CarDTO.Selector).ToList();
        }

        public List<CarDTO> GetCars(SearchDTO queryCar)
        {
            List<int> carsIdByFilter = _context.Cars
                .Include(c => c.Company)
                .Where(c => (queryCar.Brand == null || queryCar.Brand == "" || c.Brand.Contains(queryCar.Brand))
                         && (queryCar.DealerShipName == null || queryCar.DealerShipName == "" || c.Company.Name.Contains(queryCar.DealerShipName))
                         && (queryCar.Year == 0 || c.Year == queryCar.Year)
                         && (queryCar.Seat == 0 || c.Seat == queryCar.Seat)
                         && (queryCar.Bag == 0 || c.Bag == queryCar.Bag)
                         && (queryCar.Door == 0 || c.Door == queryCar.Door)
                         && (queryCar.IsFuelFull == null || c.IsFuelFull == queryCar.IsFuelFull)
                         && (queryCar.Climate == null || c.Climate == queryCar.Climate)
                         && (queryCar.Category == null || c.Category == queryCar.Category)
                         && (queryCar.Transmission == null || c.Transmission == queryCar.Transmission))
                .Select(c => c.Id).ToList();

            List<int> carsIdByDateAvailability = _context.Cars
                .Include(c => c.Reservations)
                .Where(c => carsIdByFilter.Contains(c.Id) && CheckDateAvailability(c.Reservations, queryCar))
                .Select(c=>c.Id).ToList();
            
            if ((!String.IsNullOrEmpty(queryCar.CountryPickUp) || !String.IsNullOrEmpty(queryCar.CityPickUp) || !String.IsNullOrEmpty(queryCar.LocationPickUp)) && IsDateValid(queryCar.ReserveFrom)) {
                List<int> availableLocationIdsByUser = _context.Locations
                    .Where(l => (String.IsNullOrEmpty(queryCar.CountryPickUp) || l.Country == queryCar.CountryPickUp)
                                && (String.IsNullOrEmpty(queryCar.CityPickUp) || l.City == queryCar.CityPickUp)
                                && (String.IsNullOrEmpty(queryCar.LocationPickUp) || l.Address == queryCar.LocationPickUp))
                    .Select(c => c.Id).ToList();


                var carsByLocationAvailability = _context.Cars
                    .Include(c => c.Reservations)
                    .Select(c => new
                    {
                        c.Id,
                        c.Reservations,
                        c.PickUpLocationId
                    });
                List<int> carsIdByLocationAvailability = new List<int>();

                foreach (var car in carsByLocationAvailability)
                {
                    //if car has no reservation, check if the default pickuplocation is ok for user
                    if(car.Reservations == null || car.Reservations.Count() == 0)
                    {
                        if (availableLocationIdsByUser.Contains(car.PickUpLocationId))
                            carsIdByLocationAvailability.Add(car.Id);
                    }
                    //if car has reservation, check if last dropdown before user reservation is ok for user
                    else
                    {
                        availableLocationIdsByUser.Contains(GetLastDropDownLocationIdFromDate(car.Reservations, queryCar));
                    }
                }
                return _context.Cars.Where(c => carsIdByLocationAvailability.Contains(c.Id)).Select(CarDTO.Selector).ToList();
            }
            return _context.Cars.Where(c => carsIdByDateAvailability.Contains(c.Id)).Select(CarDTO.Selector).ToList();
            
        }

        public ReservationInfoDTO GetReservationInfoForCar(int carId)
        {
            var reservationsForCar = new ReservationInfoDTO { CarId = carId };

            int currentReservationId = GetCurrentReservationId(carId);
            int nextReservationId = GetNextReservationId(carId, currentReservationId);

            if (currentReservationId == 0)
            {
                reservationsForCar.AtClient = false;
                reservationsForCar.NowAt = _context.Reservations.Include(r => r.DropDownLocation)
                                .Where(r => r.CarId == carId)
                                .OrderBy(r => Math.Abs((DateTime.Now - r.ReserveTo).TotalDays))
                                .Select(r => r.DropDownLocation)
                                .FirstOrDefault();
            }                

            if (currentReservationId != 0)
            {
                Reservation current = _context.Reservations
                                .Include(r => r.DropDownLocation)
                                .Where(r => r.Id == currentReservationId)
                                .First();

                reservationsForCar.CurrentReservationReturnDate = current.ReserveTo;
                reservationsForCar.CurrentReservationReturnLocation = current.DropDownLocation;

                reservationsForCar.AtClient = true;
                reservationsForCar.ClientEmail = _context
                                .Reservations
                                .Include(r => r.User)
                                .Where(r => r.Id == currentReservationId).Select(r => r.User.Email).First();
            }

            if(nextReservationId != 0)
            {
                Reservation next = _context
                                .Reservations
                                .Include(r => r.PickUpLocation)
                                .Where(r => r.Id == nextReservationId)
                                .First();

                reservationsForCar.NextReservationStartDate = next.ReserveFrom;
                reservationsForCar.NextReservationPickUpLocation = next.PickUpLocation;
            }
            
            return reservationsForCar;
        }

        public async Task AddNewCarAsync(Car c)
        {
            await _context.Cars.AddAsync(c);
            await _context.SaveChangesAsync();
        }

        private bool CheckDateAvailability(ICollection<Reservation> reservations, SearchDTO queryCar)
        {

            if (reservations == null) return true;

            return !reservations.Where(r => (queryCar.ReserveFrom > r.ReserveFrom && queryCar.ReserveFrom < r.ReserveTo && IsDateValid(queryCar.ReserveFrom))
                                        || (queryCar.ReserveTo > r.ReserveFrom && queryCar.ReserveTo < r.ReserveTo && IsDateValid(queryCar.ReserveTo))
                                        || (queryCar.ReserveFrom > r.ReserveFrom && queryCar.ReserveTo < r.ReserveTo && IsDateValid(queryCar.ReserveTo) && IsDateValid(queryCar.ReserveTo))
                                        || (queryCar.ReserveFrom < r.ReserveFrom && queryCar.ReserveTo > r.ReserveTo && IsDateValid(queryCar.ReserveFrom) && IsDateValid(queryCar.ReserveTo)))
                                        .Any();
        }

        private int GetLastDropDownLocationIdFromDate(ICollection<Reservation> reservations, SearchDTO queryCar)
        {
            return reservations
                .OrderBy(r => Math.Abs((queryCar.ReserveFrom - r.ReserveTo).TotalDays))
                .FirstOrDefault()
                .DropDownLocationId;
        }

        private int GetCurrentReservationId(int carId)
        {
            Reservation reservation = _context
                .Reservations
                .Where(r => r.CarId == carId && DateTime.Now < r.ReserveTo && DateTime.Now > r.ReserveFrom)
                .FirstOrDefault();

            if (reservation != null) return reservation.Id;

            return 0;
        }

        private int GetNextReservationId(int carId, int currentReservationId)
        {
            Reservation reservation = _context
                .Reservations
                .Where(r => r.CarId == carId && r.Id != currentReservationId && r.ReserveFrom > DateTime.Now)
                .OrderBy(r => DateTime.Now - r.ReserveFrom)
                .FirstOrDefault();

            if (reservation != null) return reservation.Id;

            return 0;
        }

        private bool IsDateValid(DateTime dt)
        {
            return !(dt.Year == 1 && dt.Month == 1 && dt.Day == 1);
        }

    }
}
