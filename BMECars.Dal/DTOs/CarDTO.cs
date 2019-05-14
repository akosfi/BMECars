using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace BMECars.Dal.DTOs
{
    

    public class CarDTO
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Seat { get; set; }
        public int Bag { get; set; }
        public int Door { get; set; }
        public Category Category { get; set; }
        public Transmission Transmission { get; set; }
        public Boolean IsFuelFull { get; set; }
        public Boolean Climate { get; set; }
        public string DealerShipName { get; set; }
        public int PickUpLocationId { get; set; }
        public int CompanyId { get; set; }


        public static Expression<Func<Car, CarDTO>> Selector = c => new CarDTO()
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
            DealerShipName = c.Company.Name,
            Plate = c.Plate,
            PickUpLocationId = c.PickUpLocationId,
            CompanyId = c.CompanyId
        };
    }
}
