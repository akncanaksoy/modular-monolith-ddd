using Octovis.SharedKernel.Domain;
using Octovis.User.Domain.AggregateModels.Roles;


namespace Octovis.User.Domain.AggregateModels.Claims
{
    public class Claim : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly List<RoleClaim> _roleClaims = new();
        public IReadOnlyCollection<RoleClaim> RoleClaims => _roleClaims;

        private Claim(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Claim Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Claim name cannot be empty.", nameof(name));

            return new Claim(name, description);

        }

        
    }

}
