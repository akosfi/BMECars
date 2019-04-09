using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class ReservationInfoDTO
    {
        public int CarId { get; set; }
        public bool AtClient { get; set; }
        public string ClientEmail { get; set; }
        public DateTime? CurrentReservationReturnDate { get; set; }
        public Location CurrentReservationReturnLocation { get; set; }
        public DateTime? NextReservationStartDate { get; set; }
        public Location NextReservationPickUpLocation { get; set; }
        public Location NowAt { get; set; }
    }
}
