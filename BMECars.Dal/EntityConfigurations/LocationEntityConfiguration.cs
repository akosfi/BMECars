using BMECars.Dal.Entities;
using BMECars.Dal.SeedService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMECars.Dal.EntityConfigurations
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        private readonly Lazy<ISeedService> _seedService;

        public LocationEntityConfiguration(Lazy<ISeedService> seedService)
            => _seedService = seedService;

        public void Configure(EntityTypeBuilder<Location> builder)
            => builder.HasData(_seedService.Value.Locations.ToArray());
    }
}
