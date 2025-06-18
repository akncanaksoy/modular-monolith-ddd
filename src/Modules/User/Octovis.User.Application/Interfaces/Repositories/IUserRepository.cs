using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> AddAsync(Domain.AggregateModels.Users.User user, CancellationToken cancellationToken);
        public Task<Domain.AggregateModels.Users.User> GetByIdAsync(Guid userId);
    }
}
