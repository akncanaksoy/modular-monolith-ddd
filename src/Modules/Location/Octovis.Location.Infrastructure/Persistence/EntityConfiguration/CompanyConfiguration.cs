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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.AddressType).HasConversion<int>();
        }
    }

}
