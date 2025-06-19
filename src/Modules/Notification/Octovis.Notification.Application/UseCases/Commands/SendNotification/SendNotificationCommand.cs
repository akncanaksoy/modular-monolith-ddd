using MediatR;
using Octovis.Notification.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.SendNotification
{
    public record SendNotificationCommand(NotificationRequestDto Notification) : IRequest;

}
