using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationRequests
{
    public class NotificationRequestEmail : NotificationRequest
    {
        public string? EmailTo { get; private set; }
        public string? Subject { get; private set; }
        public string? Body { get; private set; }

        public NotificationRequestEmail(string emailTo, string subject, string body)
        {
            EmailTo = emailTo;
            Subject = subject;
            Body = body;
        }

        public static NotificationRequestEmail Create(string emailTo, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(emailTo))
                throw new ArgumentException("Email adresi boş olamaz.");

          
            return new NotificationRequestEmail(emailTo, subject, body);
        }
    }

}
