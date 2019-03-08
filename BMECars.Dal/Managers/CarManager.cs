using BMECars.Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMECars.Dal.Managers
{
    public class CarManager : ICarManager
    {
        BMECarsDbContext _context;
        public CarManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
        }
        public IQueryable<CarDTO> GetCars()
        {
            var cars = from c in _context.Cars
                       select new CarDTO()
                       {
                           Id = c.Id,
                           Brand = c.Brand,
                           Image = c.Image,
                           Price = c.Price,
                           Year = c.Year,
                           Seat = c.Seat,
                           Bag = c.Bag,
                           Door = c.Door,
                           Category = c.Category,
                           Transmission = c.Transmission,
                           IsFuelFull = c.IsFuelFull,
                           Climate = c.Climate
                       };

            return cars;
        }
    }
}
