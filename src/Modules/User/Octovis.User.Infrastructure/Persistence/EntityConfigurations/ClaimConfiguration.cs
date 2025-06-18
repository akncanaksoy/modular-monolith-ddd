using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octovis.User.Domain.AggregateModels.Claims;
using Octovis.User.Domain.AggregateModels.Roles;

namespace Octovis.User.Infrastructure.Persistence.EntityConfigurations
{
    public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);


            builder.Ignore(x => x.RoleClaims);

            builder.HasMany<RoleClaim>("_roleClaims")
                .WithOne()
                .HasForeignKey(rc => rc.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
