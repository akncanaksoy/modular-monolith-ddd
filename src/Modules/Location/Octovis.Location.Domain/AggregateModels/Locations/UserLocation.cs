using Octovis.SharedKernel.Domain;


namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class UserLocation:Entity
    {
        public Guid UserId { get; private set; }

        public Guid LocationId { get; private set; }


        public UserLocation(Guid userId, Guid locationId)
        {
            UserId = userId;
            LocationId = locationId;
        }
    }
}
