using MediatR;
using Octovis.SharedKernel.Domain;
using Octovis.User.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Application.UseCases.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = Domain.AggregateModels.Users.User.Create(request.Username,
                request.Email,
                request.PasswordHash,
                request.Phone,
                request.TimeZone,
                request.LanguageCode,
                request.RoleId);


            await _userRepository.AddAsync(user, cancellationToken);
            var res = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return res > 0;

        }
    }
}
