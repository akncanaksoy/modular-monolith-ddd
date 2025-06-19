using Octovis.Notification.Domain.AggregateModels.NotificationLogs;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationRequests
{
    public abstract class NotificationRequest : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public NotificationStatus Status { get; private set; }
        public int RetryCount { get; private set; }
        public int MaxRetry { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ProcessedAt { get; private set; }
        public DateTime? SentAt { get; private set; }

        private readonly List<NotificationLog> _logs = new();
        public IReadOnlyCollection<NotificationLog> Logs => _logs;

        protected NotificationRequest(int maxRetry)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Status = NotificationStatus.Pending;
            RetryCount = 0;
            MaxRetry = maxRetry;
        }

        public void MarkAsProcessing()
        {
            Status = NotificationStatus.Processing;
            ProcessedAt = DateTime.UtcNow;
        }

        public void MarkAsSent()
        {
            Status = NotificationStatus.Processed;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsFailed(string response)
        {
            RetryCount++;
            Status = RetryCount >= MaxRetry ? NotificationStatus.Failed : NotificationStatus.Pending;
            AddLog(false, response);
        }

        public void AddLog(bool success, string response)
        {
            _logs.Add(new NotificationLog(RetryCount, success, response));
        }

        public bool CanRetry() => RetryCount < MaxRetry;
    }

}
