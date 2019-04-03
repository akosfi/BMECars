using System;
using System.Collections.Generic;
using System.Text;
using BMECars.Dal.Entities;

namespace BMECars.Dal.DTOs
{
    public class SearchDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public string Plate { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Seat { get; set; }
        public int Bag { get; set; }
        public int Door { get; set; }
        public Category? Category { get; set; }
        public Transmission? Transmission { get; set; }
        public bool? IsFuelFull { get; set; } //nullable because of query
        public bool? Climate { get; set; }
        public string DealerShipName { get; set; }

        public DateTime ReserveFrom { get; set; }
        public DateTime ReserveTo { get; set; }

        public string CountryPickUp { get; set; }
        public string CityPickUp { get; set; }
        public string LocationPickUp { get; set; }

        public string CountryDropDown { get; set; }
        public string CityDropDown { get; set; }
        public string LocationDropDown { get; set; }
    }
}
