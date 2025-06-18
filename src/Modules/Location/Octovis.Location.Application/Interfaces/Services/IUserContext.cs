using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Interfaces.Services
{
    public interface IUserContext
    {
        Guid UserId { get; }
        string Username { get; }
        List<string> Claims { get; }

        bool HasClaim(string claimName);
    }

}
