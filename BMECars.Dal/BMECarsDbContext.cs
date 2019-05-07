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
        private readonly Lazy<IEntityTypeConfiguration<User>> _userConfiguration;
        private readonly Lazy<IEntityTypeConfiguration<Company>> _companyConfiguration;
        private readonly Lazy<IEntityTypeConfiguration<Location>> _locationConfiguration;
        private readonly Lazy<IEntityTypeConfiguration<Car>> _carConfiguration;
        private readonly Lazy<IEntityTypeConfiguration<Reservation>> _reservationConfiguration;

        public BMECarsDbContext(
            DbContextOptions options,
            Lazy<IEntityTypeConfiguration<User>> userConfiguration,
            Lazy<IEntityTypeConfiguration<Company>> companyConfiguration,
            Lazy<IEntityTypeConfiguration<Location>> locationConfiguration,
            Lazy<IEntityTypeConfiguration<Car>> carConfiguration,
            Lazy<IEntityTypeConfiguration<Reservation>> reservationConfiguration
            ) : base(options)
        {
            _userConfiguration = userConfiguration;
            _companyConfiguration = companyConfiguration;
            _locationConfiguration = locationConfiguration;
            _carConfiguration = carConfiguration;
            _reservationConfiguration = reservationConfiguration;
        }

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
            modelBuilder.ApplyConfiguration(_userConfiguration.Value);
            modelBuilder.ApplyConfiguration(_companyConfiguration.Value);
            modelBuilder.ApplyConfiguration(_locationConfiguration.Value);
            modelBuilder.ApplyConfiguration(_carConfiguration.Value);
            modelBuilder.ApplyConfiguration(_reservationConfiguration.Value);

            modelBuilder.Entity<Reservation>().Property(r => r.Accepted).HasDefaultValue(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
