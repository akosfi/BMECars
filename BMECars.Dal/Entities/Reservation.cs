using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ReservationPrice { get; set; }
        public DateTime ReserveFrom { get; set; }
        public DateTime ReserveTo { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }

        public int DropDownLocationId { get; set; }
        public Location DropDownLocation { get; set; }
    }
}
