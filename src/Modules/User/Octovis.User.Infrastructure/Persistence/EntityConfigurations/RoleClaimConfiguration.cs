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
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(rc => rc.Id);
        }
    }
}
