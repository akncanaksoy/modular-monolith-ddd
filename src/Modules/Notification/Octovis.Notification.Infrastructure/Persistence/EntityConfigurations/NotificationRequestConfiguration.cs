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

    public class NotificationRequestEmailConfiguration : IEntityTypeConfiguration<NotificationRequestEmail>
    {
        public void Configure(EntityTypeBuilder<NotificationRequestEmail> builder)
        {
            builder.Property(e => e.EmailTo)
                   .HasMaxLength(150)
                   .IsRequired(false); // Çünkü SMS için null olabilir

            builder.Property(e => e.Subject)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(e => e.Body)
                   .IsRequired(false);
        }
    }

    public class NotificationRequestSmsConfiguration : IEntityTypeConfiguration<NotificationRequestSms>
    {
        public void Configure(EntityTypeBuilder<NotificationRequestSms> builder)
        {
            builder.Property(s => s.PhoneNumber)
                   .HasMaxLength(20)
                   .IsRequired(false); // Email için null olabilir

            builder.Property(s => s.Message)
                   .IsRequired(false);
        }
    }

}
