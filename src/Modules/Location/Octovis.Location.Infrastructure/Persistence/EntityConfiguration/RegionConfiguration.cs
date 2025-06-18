using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.Location.Domain.AggregateModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.EntityConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AddressType).HasConversion<int>();

            builder.HasOne(x => x.Address)
                   .WithMany()
                   .HasForeignKey(x => x.AddressId);
        }
    }

}
