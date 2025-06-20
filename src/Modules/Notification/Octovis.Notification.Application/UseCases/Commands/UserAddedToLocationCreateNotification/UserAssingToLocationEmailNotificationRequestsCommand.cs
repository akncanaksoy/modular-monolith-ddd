using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.UserAddedToLocationCreateNotification
{
    public record UserAssingToLocationEmailNotificationRequestsCommand(
 Guid userId,
 Guid locationId

) : IRequest<bool>;
}
