using MediatR;
using Octovis.Location.Contract.IntegrationEvents;
using Octovis.Notification.Application.UseCases.Commands;
using Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.EventHandlers
{
    public class UserAssignedToLocationIntegrationEventHandler : INotificationHandler<UserAssignedToLocationIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public UserAssignedToLocationIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(UserAssignedToLocationIntegrationEvent @event, CancellationToken cancellationToken)
        {

            var command = new CreateEmailNotificationRequestsCommand(
                EmailTo: @event.UserName + "@domain.com",
                Subject: "Yeni Lokasyon Ataması",
                Body: $"{@event.LocationName} adlı lokasyona atandınız."
            );

            await _mediator.Send(command, cancellationToken);
        }
    }
}
