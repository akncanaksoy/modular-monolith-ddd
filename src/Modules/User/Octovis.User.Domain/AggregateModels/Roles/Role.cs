using Octovis.SharedKernel.Domain;
using Octovis.User.Domain.AggregateModels.Claims;


namespace Octovis.User.Domain.AggregateModels.Roles
{
    public class Role : Entity, IAggregateRoot
    {
        public string Name { get; private set; } // i18n handled separately
        public string Description { get; private set; }


        private readonly List<RoleClaim> _roleClaims = new();
        public IReadOnlyCollection<RoleClaim> RoleClaims => _roleClaims;


        private Role() { }

        private Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Role Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Role name cannot be empty.", nameof(name));

            return new Role(name, description);

        }

        public void AddClaim(Guid claimId)
        {
            if (_roleClaims.Any(u => u.ClaimId == claimId))
                throw new Exception("Already assigned");

            _roleClaims.Add(new RoleClaim(Id, claimId));

        }

        public void RemoveClaim(Guid claimId)
        {
            var existingClaim = _roleClaims.FirstOrDefault(u => u.ClaimId == claimId);
            if (existingClaim == null)
                throw new Exception("Claim id not found");

            _roleClaims.Remove(existingClaim);

        }
      

    }

}
