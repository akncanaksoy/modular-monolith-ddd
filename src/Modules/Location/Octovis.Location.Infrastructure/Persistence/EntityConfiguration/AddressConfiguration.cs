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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Latitude)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Longitude)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.HasOne(x => x.Country)
                    .WithMany()
                    .HasForeignKey(x => x.CountryId);


            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId);

            builder.HasOne(x => x.District)
                   .WithMany()
                   .HasForeignKey(x => x.DistrictId);
        }


    }
}


