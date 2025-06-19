using Octovis.Notification.Domain.AggregateModels.NotificationLogs;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationRequests
{
    public abstract class NotificationRequest : Entity, IAggregateRoot
    {
        public NotificationStatus Status { get; private set; }
        public int RetryCount { get; private set; }
        public int MaxRetry { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ProcessedAt { get; private set; }
        public DateTime? SentAt { get; private set; }

        private readonly List<NotificationLog> _logs = new();
        public IReadOnlyCollection<NotificationLog> Logs => _logs;

        protected NotificationRequest()
        {
            CreatedAt = DateTime.UtcNow;
            Status = NotificationStatus.Pending;
            RetryCount = 0;
            MaxRetry = 3;
        }
       
       
        public void IncreaseRetry()
        {
            RetryCount++;
        }
        public void MarkAsSent()
        {
            Status = NotificationStatus.Completed;
            ProcessedAt = DateTime.UtcNow;
        }
        public void MarkAsFailed()
        {
            RetryCount++;

            if (RetryCount >= MaxRetry)
            {
                Status = NotificationStatus.Failed;
            }
        }
        public bool CanBeSent() => Status == NotificationStatus.Pending && RetryCount < MaxRetry;
        public bool CanRetry() => RetryCount < MaxRetry;

       
    }

}
