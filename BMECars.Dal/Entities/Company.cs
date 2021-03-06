﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Location> PickUpLocations { get; set; }

        public string UserId { get; set; }
        public User Owner { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<CompanyAdmin> CompanyAdmins { get; set; }
    }
}
