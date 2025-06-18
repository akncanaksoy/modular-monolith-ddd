using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Octovis.User.Domain.AggregateModels.Users;

namespace Octovis.User.Infrastructure.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.AggregateModels.Users.User>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregateModels.Users.User> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Phone).HasMaxLength(20);


            builder.Ignore(x => x.UserClaims);

            builder.HasMany<UserClaim>("_userClaims")
                   .WithOne()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
