using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Octovis.Notification.Domain.AggregateModels.NotificationLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Persistence.EntityConfigurations
{
    public class NotificationLogConfiguration : IEntityTypeConfiguration<NotificationLog>
    {
        public void Configure(EntityTypeBuilder<NotificationLog> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.AttemptNo).IsRequired();
            builder.Property(l => l.AttemptTime).IsRequired();
            builder.Property(l => l.Success).IsRequired();
            builder.Property(l => l.Response).HasMaxLength(1000);
        }
    }
}
