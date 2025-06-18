using MediatR;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations.Events
{
    public class LocationCreatedEvent : IDomainEvent ,INotification
    {
        public Guid LocationId { get; }
        public LocationType LocationType { get; }
        public string Name { get; }
        public DateTime OccurredOn { get; }

        public LocationCreatedEvent(Guid locationId, string name, LocationType locationType)
        {
            LocationId = locationId;
            Name = name;
            OccurredOn = DateTime.UtcNow;
            LocationType = locationType;
        }
    }
}
