using MediatR;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Contract.IntegrationEvents;
using Octovis.Location.Domain.AggregateModels.Locations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.EventHandlers
{
    public class LocationCreatedEventHandler : INotificationHandler<LocationCreatedEvent>
    {
        IIntegrationEventPublisher _eventPublisher;
        public LocationCreatedEventHandler(IIntegrationEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task Handle(LocationCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new LocationCreatedIntegrationEvent(notification.LocationId, notification.Name, (int)notification.LocationType);

            await _eventPublisher.PublishAsync(integrationEvent);

        }
    }
}
