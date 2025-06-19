using Microsoft.EntityFrameworkCore;
using Octovis.Notification.Domain.AggregateModels.NotificationLogs;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;


namespace Octovis.Notification.Infrastructure.Persistence.Context
{

    public class NotificationDbContext : DbContext
    {
        public DbSet<NotificationRequest> NotificationRequests { get; set; }
        public DbSet<NotificationRequestEmail> EmailRequests { get; set; }
        public DbSet<NotificationRequestSms> SmsRequests { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("notification"); 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
