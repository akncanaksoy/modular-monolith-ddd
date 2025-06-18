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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Token).IsRequired().HasMaxLength(500);
            builder.Property(rt => rt.ExpiresAt).IsRequired();
            builder.Property(rt => rt.CreatedAt).IsRequired();
            builder.Property(rt => rt.ReplacedByToken).HasMaxLength(500);
        }
    }
}
