using MediatR;
using Microsoft.Extensions.Logging;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Contract.IntegrationEvents;
using Octovis.Location.Domain.AggregateModels.Locations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.EventHandlers.DomainEventHandlers
{
    public class UserAssignedToLocationCreatedEventHandler : INotificationHandler<UserAssignedToLocationCreatedEvent>
    {
        IIntegrationEventPublisher _eventPublisher;
        public UserAssignedToLocationCreatedEventHandler(IIntegrationEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task Handle(UserAssignedToLocationCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new UserAssignedToLocationIntegrationEvent(notification.LocationId, notification.LocationName, notification.UserId, notification.UserName);

            await _eventPublisher.PublishAsync(integrationEvent);

        }
    }

}
