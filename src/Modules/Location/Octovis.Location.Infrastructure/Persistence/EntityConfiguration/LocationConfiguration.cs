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
    public class LocationConfiguration : IEntityTypeConfiguration<Domain.AggregateModels.Locations.Location>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregateModels.Locations.Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.Type)
                   .HasConversion<int>();

            builder.HasOne(x => x.Dealer)
                   .WithOne()
                   .HasForeignKey<Dealer>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Company)
                   .WithOne()
                   .HasForeignKey<Company>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Region)
                   .WithOne()
                   .HasForeignKey<Region>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Area)
                   .WithOne()
                   .HasForeignKey<Area>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Room)
                   .WithOne()
                   .HasForeignKey<Room>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserLocations)
                   .WithOne()
                   .HasForeignKey(x => x.LocationId);
        }
    }

}
