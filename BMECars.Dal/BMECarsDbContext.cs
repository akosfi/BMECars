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

            //Foregin keys
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            //Seed
            
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "Bardi auto", UserId = "26ed8a02-70ff-497c-9c68-ee7913225c7e" });

            modelBuilder.Entity<Car>().HasData(new Car { Id = 1, Brand = "Audi", Bag = 2, Category = Category.Coupe, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 2, Brand = "BMW", Bag = 2, Category = Category.Coupe, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 3, Brand = "Audi", Bag = 2, Category = Category.Coupe, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 4, Brand = "Toyota", Bag = 2, Category = Category.SUV, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 5, Brand = "Tesla", Bag = 2, Category = Category.Coupe, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });

            modelBuilder.Entity<Location>().HasData(new Location { Id = 1, Address = "asdas street.", City = "Budapest", Country = "Hungary", IsGlobal = true, CompanyId = 1 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
