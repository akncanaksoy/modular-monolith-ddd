using MediatR;

namespace Octovis.Location.Contract.IntegrationEvents
{
    public class UserAssignedToLocationIntegrationEvent : INotification
    {
        public Guid LocationId { get; }
        public string LocationName { get; }
        public Guid UserId { get; }
        public string UserName { get; }
        public DateTime OccurredOn { get; }

        public UserAssignedToLocationIntegrationEvent(Guid locationId, string locationName, Guid userId, string userName)
        {
            LocationId = locationId;
            LocationName = locationName;
            UserId = userId;
            UserName = userName;
            OccurredOn = DateTime.UtcNow;

        }
    }
}
