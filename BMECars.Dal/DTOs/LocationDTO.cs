using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public bool IsGlobal { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
    }
}
