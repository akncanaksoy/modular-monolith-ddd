using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Domain.AggregateModels.NotificationRequests
{
    public enum NotificationStatus
    {
        Pending,
        Processing,
        Completed,
        Failed
    }
}
