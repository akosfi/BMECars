using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class User : IdentityUser
    {

        //public override string Id { get; set; }

        [PersonalData]
        public string Password { get; set; }
        [PersonalData]
        public DateTime BirthDate { get; set; }
        [PersonalData]
        public string FullName { get; set; }

        /*[ForeignKey("BillingData")]
        public int? BillingDataId { get; set; }*/
        public BillingData BillingData { get; set; }


        public ICollection<CompanyAdmin> CompanyAdmins { get; set; } //Companies where the user is admin
        public ICollection<Company> Companies { get; set; } //Companies of the user
        public ICollection<Reservation> Reservations { get; set; }
    }
}
