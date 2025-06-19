using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationRequests
{
    public class NotificationRequestSms : NotificationRequest
    {
        public string PhoneNumber { get; private set; }
        public string Message { get; private set; }

        public NotificationRequestSms(string phoneNumber, string message, int maxRetry)
            : base(maxRetry)
        {
            PhoneNumber = phoneNumber;
            Message = message;
        }
    }

}
