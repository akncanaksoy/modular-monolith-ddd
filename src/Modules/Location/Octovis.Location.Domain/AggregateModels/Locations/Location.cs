using Octovis.Location.Domain.AggregateModels.Locations.Events;
using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class Location : Entity, IAggregateRoot
    {
        public LocationType Type { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid? ParentId { get; private set; }


        public Dealer? Dealer { get; private set; }
        public Company? Company { get; private set; }
        public Region? Region { get; private set; }
        public Area? Area { get; private set; }
        public Room? Room { get; private set; }


        private readonly List<UserLocation> _userLocations = new();
        public IReadOnlyCollection<UserLocation> UserLocations => _userLocations;


        private Location() { } // EF

        private Location(Guid id, LocationType type, string name, string description, Guid? parentId)
        {
            Id = id;
            Type = type;
            Name = name;
            Description = description;
            ParentId = parentId;
        }

        public static Location Create(Guid parentId, LocationType type, string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Name is required");

            return new Location(Guid.NewGuid(),type, $"i18n_{name}", $"i18n_{description}", parentId);
        }

        public void SetDealer(Dealer dealer)
        {
            if (Type != LocationType.Dealer)
                throw new InvalidOperationException("Location type must be Dealer to set Dealer info.");
            Dealer = dealer;

            this.AddDomainEvent(new LocationCreatedEvent(this.Id, this.Name, this.Type));

        }

        public void SetCompany(Company company)
        {
            if (Type != LocationType.Company)
                throw new InvalidOperationException("Location type must be Company to set Company info.");
            Company = company;

            this.AddDomainEvent(new LocationCreatedEvent(this.Id, this.Name, this.Type));

        }

        public void SetRegion(Region region)
        {
            if (Type != LocationType.Region)
                throw new InvalidOperationException("Location type must be Regino to set Company info.");
            Region = region;

            this.AddDomainEvent(new LocationCreatedEvent(this.Id, this.Name, this.Type));

        }

        public void SetArea(Area area)
        {
            if (Type != LocationType.Area)
                throw new InvalidOperationException("Location type must be Area to set Area info.");
            Area = area;

            this.AddDomainEvent(new LocationCreatedEvent(this.Id, this.Name, this.Type));
        }

        public void AddUser(Guid userId, string username)
        {
            if (_userLocations.Any(u => u.UserId == userId))
                throw new Exception("User is already assigned to this location.");

            _userLocations.Add(new UserLocation(userId, Id));

            this.AddDomainEvent(new UserAssignedToLocationCreatedEvent(Id, Name, userId, username));
        }

        public void RemoveUser(Guid userId)
        {

            var existingUser = _userLocations.FirstOrDefault(u => u.UserId == userId);

            if (existingUser == null)
                throw new Exception("User is not defined");

            _userLocations.Remove(existingUser);

            //this.AddDomainEvent(new UserRemovedFromLocationDomainEvent(userId, Id));

        }

        public void CanBeChildOfOrThrow(LocationType parentLocationType)
        {
            if ((int)parentLocationType + 1 != (int)Type)
            {
                throw new BusinessRuleException($"Location type {Type} cannot be a child of {parentLocationType}.");
            }

        }


    }

}
