using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }


        public BillingData BillingData { get; set; }


        public ICollection<CompanyAdmin> CompanyAdmins { get; set; } //Companies where the user is admin
        public ICollection<Company> Companies { get; set; } //Companies of the user
        public ICollection<Reservation> Reservations { get; set; }
    }
}
