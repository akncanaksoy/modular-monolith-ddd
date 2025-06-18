using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.User.Domain.AggregateModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Infrastructure.Persistence.EntityConfigurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(uc => uc.Id);

            builder.HasIndex(x => new { x.UserId, x.ClaimId }).IsUnique();

        }
    }
}
