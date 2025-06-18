using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.Context
{
    public class LocationDbContextFactory : IDesignTimeDbContextFactory<LocationDbContext>
    {
        public LocationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocationDbContext>();

            // Migration sırasında kullanılacak connection string
            optionsBuilder.UseNpgsql("User ID=postgres;Password=farm.111;Host=192.168.8.2;Port=5434;Database=Octovis_Development;");

            return new LocationDbContext(optionsBuilder.Options);
        }
    }
}
