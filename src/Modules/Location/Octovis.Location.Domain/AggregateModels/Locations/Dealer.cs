using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.SharedKernel.Domain;


namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class Dealer : Entity
    {
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public AddressType AddressType { get; private set; }
        public Guid AddressId { get; private set; }
        public bool IsActive { get; private set; }


        private Dealer() { } // EF
      
        private Dealer(Guid id,string email, string phoneNumber, AddressType addressType, Guid addressId)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            AddressType = addressType;
            AddressId = addressId;
            IsActive = true;
        }

        public static Dealer Create(Guid id, string email, string phoneNumber, AddressType addressType, Guid addressId)
        {
            return new Dealer(Guid.NewGuid(), email, phoneNumber, addressType, addressId);
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }

}
