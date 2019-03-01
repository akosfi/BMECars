using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public bool IsGlobal { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Reservation> ReservationsPickUp { get; set; }

        public ICollection<Reservation> ReservationsDropDown { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
