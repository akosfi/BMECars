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
    }
}
