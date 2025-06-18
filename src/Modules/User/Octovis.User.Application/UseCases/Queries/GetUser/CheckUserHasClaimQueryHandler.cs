using MediatR;
using Octovis.SharedKernel.Exceptions;
using Octovis.User.Application.Interfaces.Repositories;
using Octovis.User.Conract.Queries;
using Octovis.User.Domain.AggregateModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Application.UseCases.Queries.GetUser
{
    public class CheckUserHasClaimQueryHandler : IRequestHandler<CheckUserHasClaimQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public CheckUserHasClaimQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckUserHasClaimQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user is null)
                throw new NotFoundExpcetion($"{request.UserId}");

            return user.HasClaim(request.ClaimId);
        }
    }

}
