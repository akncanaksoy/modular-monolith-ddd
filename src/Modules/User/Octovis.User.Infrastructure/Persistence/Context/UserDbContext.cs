using Microsoft.EntityFrameworkCore;
using Octovis.User.Domain.AggregateModels.Roles;
using Octovis.User.Domain.AggregateModels.Users;

namespace Octovis.User.Infrastructure.Persistence.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        // DbSets
        //public DbSet<Region> Regions => Set<Region>();

        public DbSet<Domain.AggregateModels.Users.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Domain.AggregateModels.Claims.Claim> Claims { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("user"); // şemayı burada belirttik. 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
