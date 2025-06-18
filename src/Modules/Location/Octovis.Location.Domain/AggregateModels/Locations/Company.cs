using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class Company : Entity
    {
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public AddressType AddressType { get; private set; }
        public Guid AddressId { get; private set; }
        public bool IsActive { get; private set; }

        private Company() { }

        private Company(Guid id, string email, string phoneNumber, AddressType addressType, Guid addressId)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            AddressType = addressType;
            AddressId = addressId;
            IsActive = true;
        }

        public static Company Create(Guid id, string email, string phoneNumber, AddressType addressType, Guid addressId)
        {
            return new Company(Guid.NewGuid(), email, phoneNumber, addressType, addressId);
        }

        public void Deactivate() => IsActive = false;
    }
}
