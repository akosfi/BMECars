using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BMECars.Dal.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BMECars.Dal
{
    public class BMECarsDbContext : IdentityDbContext<User>
    {
        public BMECarsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAdmin> CompanyAdmins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BillingData> BillingDatas { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<Extra> Extras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(o => o.PickUpLocation)
                .WithMany(o => o.ReservationsPickUp);

            modelBuilder.Entity<Reservation>()
                .HasOne(o => o.DropDownLocation)
                .WithMany(o => o.ReservationsDropDown);

           // modelBuilder.Entity<BillingData>().HasOne(o => o.User).WithOne(o => o.BillingData);


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
