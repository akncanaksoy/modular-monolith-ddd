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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            // Backing field for districts
            builder.Ignore(x => x.Cities);

            builder.HasMany<City>("_cities")
                   .WithOne()
                   .HasForeignKey(c => c.CountryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
