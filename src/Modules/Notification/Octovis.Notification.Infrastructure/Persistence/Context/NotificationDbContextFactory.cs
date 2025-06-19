using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Persistence.Context
{
    public class NotificationDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
    {
        public NotificationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();

            // Migration sırasında kullanılacak connection string
            optionsBuilder.UseNpgsql("User ID=postgres;Password=farm.111;Host=192.168.8.2;Port=5434;Database=Octovis_Development;");

            return new NotificationDbContext(optionsBuilder.Options);
        }
    }
}
