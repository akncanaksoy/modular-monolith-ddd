using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Enums;
using Octovis.User.Domain.AggregateModels.Claims;
using Octovis.User.Domain.AggregateModels.Roles;

namespace Octovis.User.Domain.AggregateModels.Users
{

    public class User : Entity, IAggregateRoot
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public TimeZoneType TimeZone { get; private set; }
        public LanguageCodeType LanguageCode { get; private set; }
        public Guid RoleId { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        

        private readonly List<UserClaim> _userClaims = new();
        public IReadOnlyCollection<UserClaim> UserClaims => _userClaims;


        private User(string username, string passwordHash, string email, string phone, TimeZoneType timeZone, LanguageCodeType languageCode, Guid roleId, DateTime expireDate, bool isActive)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Phone = phone;
            TimeZone = timeZone;
            LanguageCode = languageCode;
            RoleId = roleId;
            ExpireDate = expireDate;
            IsActive = isActive;
        }

        private User() { } // EF için


        public static User Create(string username, string passwordHash, string email, string phone, TimeZoneType timeZone, LanguageCodeType languageCode, Guid roleId)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                throw new ArgumentException("Username must be at least 3 characters.", nameof(username));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email address.", nameof(email));
            if (roleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty.", nameof(roleId));

            return new User(username, passwordHash, email, phone, timeZone, languageCode, roleId, DateTime.UtcNow, true);

        }

        public void ChangeRole(Guid roleId)
        {

            if (roleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty.", nameof(roleId));

            RoleId = roleId;
        }

        public void AddClaim(Guid claimId)
        {

            if (_userClaims.Any(u => u.ClaimId == claimId))
                throw new Exception("Already assigned");

            _userClaims.Add(new UserClaim(Id, claimId));
        }

        public void RemoveClaim(Guid claimId)
        {
            var existing = _userClaims.FirstOrDefault(u => u.ClaimId == claimId);
            if (existing == null)
                throw new Exception("Claim not found");

            _userClaims.Remove(existing);
        }

        public bool HasClaim(Guid claimId)
        {
            return _userClaims.Any(u => u.ClaimId == claimId);
        }


    }


}
