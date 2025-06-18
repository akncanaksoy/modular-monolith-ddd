using MediatR;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.User.Conract.DTOs;
using Octovis.User.Conract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CheckUserHasClaimAsync(CheckUserHasClaimQuery request)
        {
            return await _mediator.Send(request);
        }

        public async Task<UserDto> GetUserByIdAsync(GetUserByIdQuery request)
        {
            return await _mediator.Send(request);

        }
    }
}
