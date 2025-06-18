using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Interfaces.Services
{
    public interface IAuthorizationService
    {
        void CheckPermission(string claimName);
        Guid GetCurrentUserId();
    }

}
