using Octovis.User.Conract.DTOs;
using Octovis.User.Conract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDto> GetUserByIdAsync(GetUserByIdQuery request);
        public Task<bool> CheckUserHasClaimAsync(CheckUserHasClaimQuery request); 
    }
}
