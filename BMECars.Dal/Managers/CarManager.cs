using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<CarDTO> GetCarsForCompany(int companyId)
        {
            return _context.Cars
                .Where(c => c.CompanyId == companyId)
                .Select(CarDTO.Selector).ToList();
        }

        public List<CarDTO> GetCars(SearchDTO queryCar)
        {
            var helperLocationId = _context.Locations.Where(l => l.Country == queryCar.CountryPickUp);
            
            var cars = _context.Cars
                .Include(c => c.Company)
                .Include(c => c.Reservations)
                .Include("Reservations.PickUpLocation")
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

                .Where(c => CheckDateAvailability(c.Reservations, queryCar))
                //.Where( predicate )
                //.Where(c => CheckLocationAvailability(c.Reservations, queryCar))
                .Select(CarDTO.Selector);

            return cars.ToList();
        }

        private Expression<Func<Car, bool>> predicate = c => c.Reservations.Any();

        private bool CheckDateAvailability(ICollection<Reservation> reservations, SearchDTO queryCar)
        {

            if (reservations == null) return true;

            return !reservations.Where(r => (queryCar.ReserveFrom > r.ReserveFrom && queryCar.ReserveFrom < r.ReserveTo && IsDateValid(queryCar.ReserveFrom))
                                        || (queryCar.ReserveTo > r.ReserveFrom && queryCar.ReserveTo < r.ReserveTo && IsDateValid(queryCar.ReserveFrom))
                                        || (queryCar.ReserveFrom > r.ReserveFrom && queryCar.ReserveTo < r.ReserveTo && IsDateValid(queryCar.ReserveTo) && IsDateValid(queryCar.ReserveTo))
                                        || (queryCar.ReserveFrom < r.ReserveFrom && queryCar.ReserveTo > r.ReserveTo && IsDateValid(queryCar.ReserveFrom) && IsDateValid(queryCar.ReserveTo)))
                                        .Any();
        }


        /*private bool CheckLocationAvailability(ICollection<Reservation> reservations, SearchDTO queryCar)
        {
            if (queryCar.CountryPickUp == "" || queryCar.CityPickUp == "") return true;
            if (!IsDateValid(queryCar.ReserveFrom)) return true;
            if (reservations == null || reservations.Count() == 0) return true;

            Reservation closest = reservations.OrderBy(r => Math.Abs((queryCar.ReserveFrom - r.ReserveTo).TotalDays)).First();

            
                                
            
            return true;
        }*/

        private bool IsDateValid(DateTime dt)
        {
            return !(dt.Year == 1 && dt.Month == 1 && dt.Day == 1);
        }

        public List<string> GetAvailableCarBrands()
        {
            return _context.Cars.Select(c => c.Brand).Distinct().ToList();
        }
    }
}
