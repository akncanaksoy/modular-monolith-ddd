using MediatR;
using Octovis.User.Application.Interfaces.Repositories;
using Octovis.User.Conract.DTOs;
using Octovis.User.Conract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Application.UseCases.Queries.GetUser
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.UserId);

            UserDto userDto = new();

            userDto.ConvertUserDto(user.Username,user.Email,user.PasswordHash,user.RoleId.ToString());

            return userDto;

        }
    }
}
