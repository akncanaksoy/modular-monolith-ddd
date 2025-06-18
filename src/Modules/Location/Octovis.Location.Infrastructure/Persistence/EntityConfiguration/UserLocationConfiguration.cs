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
    public class UserLocationConfiguration : IEntityTypeConfiguration<UserLocation>
    {
        public void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.UserId, x.LocationId }).IsUnique();
        }
    }

}
