using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class CarExtra
    {
        public int Id { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
    }
}
