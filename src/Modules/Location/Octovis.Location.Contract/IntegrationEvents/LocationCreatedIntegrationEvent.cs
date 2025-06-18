using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Contract.IntegrationEvents
{
    public class LocationCreatedIntegrationEvent:INotification
    {
        public Guid LocationId { get; }
        public int LocationType { get; }
        public string Name { get; }
        public DateTime OccurredOn { get; }

        public LocationCreatedIntegrationEvent(Guid locationId, string name, int locationType)
        {
            LocationId = locationId;
            Name = name;
            OccurredOn = DateTime.UtcNow;
            LocationType = locationType;
        }
    }
}
