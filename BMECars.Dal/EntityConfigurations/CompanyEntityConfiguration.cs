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
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        private readonly Lazy<ISeedService> _seedService;

        public CompanyEntityConfiguration(Lazy<ISeedService> seedService)
            => _seedService = seedService;

        public void Configure(EntityTypeBuilder<Company> builder)
            => builder.HasData(_seedService.Value.Companies.ToArray());
    }
}
