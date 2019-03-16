using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.EntityFrameworkCore;
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


        public CarHeaderDTO GetCarHeader(int id)
        {
            var car = _context.Cars.Select(c => new CarHeaderDTO {
                Id = c.Id,
                Brand = c.Brand,
                Price = c.Price
            }).SingleOrDefault(c=> c.Id == id);
            
            return car;
        }

        public List<CarDTO> GetCars(SearchDTO queryCar)
        {
            
            var cars = _context.Cars.Include(c => c.Company)
                .Select(c => new CarDTO()
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
                    Climate = c.Climate,
                    DealerShipName = c.Company.Name
                })
                .Where(c => (queryCar.Brand == null || queryCar.Brand == "" || c.Brand.Contains(queryCar.Brand))
                         && (queryCar.DealerShipName == null || queryCar.DealerShipName == "" || c.DealerShipName.Contains(queryCar.DealerShipName))
                         && (queryCar.Year == 0 || c.Year == queryCar.Year)
                         && (queryCar.Seat == 0 || c.Seat == queryCar.Seat)
                         && (queryCar.Bag == 0 || c.Bag == queryCar.Bag )
                         && (queryCar.Door == 0 || c.Door == queryCar.Door)
                         && (queryCar.IsFuelFull == null || c.IsFuelFull == queryCar.IsFuelFull)
                         && (queryCar.Climate == null || c.Climate == queryCar.Climate)
                         && (queryCar.Category == null || c.Category == queryCar.Category)
                         && (queryCar.Transmission == null || c.Transmission == queryCar.Transmission));
                

            return cars.ToList();
        }
    }
}
