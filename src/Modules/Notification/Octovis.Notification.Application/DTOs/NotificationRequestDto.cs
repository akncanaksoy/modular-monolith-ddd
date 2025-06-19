using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.DTOs
{
    //public class NotificationRequestDto
    //{
    //    public Guid Id { get; set; }
    //    public NotificationStatus Status { get; set; }
    //    public int RetryCount { get; set; }
    //    public int MaxRetry { get; set; }
    //    public NotificationType NotificationType { get; set; } // "Email" or "Sms"    
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime? ProcessedAt { get; set; }
    //    public DateTime? SentAt { get;  set; }

    //    // Ortak olmayanlar:

    //    public string? PhoneNumber { get; private set; }
    //    public string? Message { get; private set; }


    //    public string? EmailTo { get; set; }
    //    public string? Subject { get; set; }
    //    public string? Body { get; set; }
    //}


    public abstract class NotificationRequestDto
    {
        public Guid Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public NotificationStatus Status { get; set; }
        public int RetryCount { get; set; }
        public int MaxRetry { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }

    // Email DTO
    public class NotificationRequestEmailDto : NotificationRequestDto
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    // SMS DTO
    public class NotificationRequestSmsDto : NotificationRequestDto
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
