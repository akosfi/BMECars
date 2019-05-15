using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string CarPlate { get; set; }
        public int ReservationPrice { get; set; }
        public DateTime ReserveFrom { get; set; }
        public DateTime ReserveTo { get; set; }
        public ReservationStatus Accepted { get; set; }
        public int CarId { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropDownLocation { get; set; }

        public Location PreviousReservationEnd { get; set; }
        public DateTime PreviousReservationEndDate { get; set; }

        public Location NextReservationStart { get; set; }
        public DateTime NextReservationStartDate { get; set; }


    }
}
