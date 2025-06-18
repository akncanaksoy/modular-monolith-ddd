using MediatR;
using Octovis.User.Conract.DTOs;

namespace Octovis.User.Conract.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
