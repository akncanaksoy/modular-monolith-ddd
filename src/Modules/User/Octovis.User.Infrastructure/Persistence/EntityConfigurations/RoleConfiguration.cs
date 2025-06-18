using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.User.Domain.AggregateModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Infrastructure.Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Description).HasMaxLength(250);


            builder.Ignore(x => x.RoleClaims);

            builder.HasMany<RoleClaim>("_roleClaims")
                .WithOne()
                .HasForeignKey(rc => rc.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
