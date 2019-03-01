﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class CompanyAdmin
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
