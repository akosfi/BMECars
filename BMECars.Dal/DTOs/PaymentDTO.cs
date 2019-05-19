using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class PaymentDTO
    {
        //ReservationDetails
        public int Id { get; set; } //carId
        public DateTime ReserveFrom { get; set; }
        public DateTime ReserveTo { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropDownLocationId { get; set; }

        //BillingData
        public int BillingDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
    }
}
