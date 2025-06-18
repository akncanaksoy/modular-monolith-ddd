using MediatR;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations.Events
{
    public class UserAssignedToLocationCreatedEvent : IDomainEvent, INotification
    {
        public Guid LocationId { get; }
        public string LocationName { get; }
        public Guid UserId { get; }
        public string UserName { get; }
        public DateTime OccurredOn { get; }

        public UserAssignedToLocationCreatedEvent(Guid locationId, string locationName, Guid userId, string userName)
        {
            LocationId = locationId;
            LocationName = locationName;
            UserId = userId;
            UserName = userName;
            OccurredOn = DateTime.UtcNow;

        }
    }
}
