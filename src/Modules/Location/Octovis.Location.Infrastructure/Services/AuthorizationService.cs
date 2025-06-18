using Octovis.Location.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserContext _userContext;

        public AuthorizationService(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void CheckPermission(string claimName)
        {
            if (!_userContext.HasClaim(claimName))
                throw new UnauthorizedAccessException($"Permission denied: {claimName}");
        }

        public Guid GetCurrentUserId() => _userContext.UserId;
    }

}
