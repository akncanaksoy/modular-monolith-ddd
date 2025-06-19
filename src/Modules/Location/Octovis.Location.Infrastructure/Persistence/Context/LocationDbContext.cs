using Microsoft.EntityFrameworkCore;
using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.Location.Domain.AggregateModels.Locations;

namespace Octovis.Location.Infrastructure.Persistence.Context
{
    public class LocationDbContext : DbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Domain.AggregateModels.Locations.Location> Locations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("location"); // şemayı burada belirttik. 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }



    }
}
