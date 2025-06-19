using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationLogs
{
    public class NotificationLog : Entity
    {
        public int AttemptNo { get; private set; }
        public DateTime AttemptTime { get; private set; }
        public bool Success { get; private set; }
        public string Response { get; private set; }

        public NotificationLog(int attemptNo, bool success, string response)
        {
            AttemptNo = attemptNo;
            AttemptTime = DateTime.UtcNow;
            Success = success;
            Response = response;
        }
    }
}
