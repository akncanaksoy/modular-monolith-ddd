using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.SharedKernel.Domain;


namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class Region : Entity
    {
        public AddressType AddressType { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        private Region() { }

        public Region(AddressType addressType, Guid addressId)
        {
            AddressType = addressType;
            AddressId = addressId;
        }
    }

   
}
