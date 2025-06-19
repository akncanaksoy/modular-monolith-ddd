using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateSms
{
    public record CreateSmsNotificationCommand(
     string PhoneNumber,
     string Message
 ) : IRequest<bool>;
}
