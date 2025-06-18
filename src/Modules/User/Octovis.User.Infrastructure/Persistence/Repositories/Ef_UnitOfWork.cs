using Octovis.SharedKernel.Domain;
using Octovis.User.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Infrastructure.Persistence.Repositories
{
    public class Ef_UnitOfWork : IUnitOfWork
    {

        private readonly UserDbContext _context;

        public Ef_UnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
