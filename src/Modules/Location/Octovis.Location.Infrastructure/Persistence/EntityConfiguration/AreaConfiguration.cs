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
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

}
