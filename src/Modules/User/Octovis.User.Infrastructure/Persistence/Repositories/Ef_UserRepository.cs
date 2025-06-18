using Microsoft.EntityFrameworkCore;
using Octovis.SharedKernel.Enums;
using Octovis.User.Application.Interfaces.Repositories;
using Octovis.User.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octovis.User.Infrastructure.Persistence.Repositories
{
    public class Ef_UserRepository : IUserRepository
    {

        private readonly UserDbContext _context;


        public Ef_UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Domain.AggregateModels.Users.User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            return true; // SaveChanges UoW'de yapılacak
        }

        public async Task<Domain.AggregateModels.Users.User> GetByIdAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
