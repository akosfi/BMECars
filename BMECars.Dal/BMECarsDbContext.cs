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
            
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "Bardi auto", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" });
            modelBuilder.Entity<Company>().HasData(new Company { Id = 2, Name = "Top Cars", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" });
            modelBuilder.Entity<Company>().HasData(new Company { Id = 3, Name = "EuroCar", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" });
            modelBuilder.Entity<Company>().HasData(new Company { Id = 4, Name = "MyWay", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" });

            modelBuilder.Entity<Location>().HasData(new Location { Id = 1, Address = "Ferihegy Airport", City = "Budapest", Country = "Hungary", IsGlobal = true, CompanyId = 1 });

            modelBuilder.Entity<Car>().HasData(new Car { Id = 1, Brand = "Audi", Bag = 2, Category = Category.Coupe, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 2, Brand = "Audi", Bag = 2, Category = Category.SUV, Climate = true, Door = 3, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 3, Brand = "Audi", Bag = 2, Category = Category.Coupe, Climate = false, Door = 2, Price = 20000, Seat = 2, IsFuelFull = false, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 4, Brand = "BMW", Bag = 4, Category = Category.SUV, Climate = true, Door = 2, Price = 15000, Seat = 2, IsFuelFull = false, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 5, Brand = "BMW", Bag = 6, Category = Category.Crossover, Climate = true, Door = 2, Price = 20000, Seat = 2, IsFuelFull = false, Transmission = Transmission.Manual, Year = 2002, CompanyId = 1, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 6, Brand = "BMW", Bag = 2, Category = Category.MPV, Climate = true, Door = 4, Price = 20000, Seat = 2, IsFuelFull = false, Transmission = Transmission.Manual, Year = 2012, CompanyId = 2, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 7, Brand = "BMW", Bag = 2, Category = Category.Coupe, Climate = false, Door = 5, Price = 20000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 2, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 8, Brand = "Jeep", Bag = 3, Category = Category.Crossover, Climate = true, Door = 6, Price = 15000, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2000, CompanyId = 3, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 9, Brand = "Tesla", Bag = 2, Category = Category.Coupe, Climate = false, Door = 2, Price = 15300, Seat = 2, IsFuelFull = false, Transmission = Transmission.Manual, Year = 2000, CompanyId = 3, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 10, Brand = "Tesla", Bag = 5, Category = Category.MPV, Climate = true, Door = 9, Price = 15010, Seat = 2, IsFuelFull = true, Transmission = Transmission.Automatic, Year = 2019, CompanyId = 3, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 11, Brand = "Toyota", Bag = 4, Category = Category.Crossover, Climate = false, Door = 2, Price = 15900, Seat = 2, IsFuelFull = true, Transmission = Transmission.Manual, Year = 2015, CompanyId = 4, PickUpLocationId = 1 });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 12, Brand = "Toyota", Bag = 3, Category = Category.MPV, Climate = true, Door = 12, Price = 150000, Seat = 2, IsFuelFull = false, Transmission = Transmission.Manual, Year = 2016, CompanyId = 4, PickUpLocationId = 1 });

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
