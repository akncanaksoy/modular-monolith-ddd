using Octovis.Notification.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Queries.GetPendingStatusNotification
{
    public class GetNotificationPendingStatusResponse
    {
        public List<NotificationRequestDto> Notifications { get; set; }    

    }
}
