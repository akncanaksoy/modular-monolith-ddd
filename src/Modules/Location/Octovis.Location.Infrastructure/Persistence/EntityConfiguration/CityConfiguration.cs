using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.Location.Domain.AggregateModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.EntityConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

            // Backing field for districts
            builder.Ignore(x => x.Districts);

            builder.HasMany<District>("_districts")
                   .WithOne()
                   .HasForeignKey(d => d.CityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
