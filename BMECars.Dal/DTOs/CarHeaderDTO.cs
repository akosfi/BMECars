using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class CarHeaderDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Plate { get; set; }
    }
}
