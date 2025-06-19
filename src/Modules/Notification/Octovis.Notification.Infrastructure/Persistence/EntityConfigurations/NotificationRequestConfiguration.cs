using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Persistence.EntityConfigurations
{
    public class NotificationRequestConfiguration : IEntityTypeConfiguration<NotificationRequest>
    {
        public void Configure(EntityTypeBuilder<NotificationRequest> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasDiscriminator<string>("RequestType")
                   .HasValue<NotificationRequestEmail>("Email")
                   .HasValue<NotificationRequestSms>("Sms");

            builder.HasMany(r => r.Logs)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
