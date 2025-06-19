using Octovis.Notification.Infrastructure.Persistence.Context;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Persistence.Repositories
{
    public class Ef_UnitOfWork : IUnitOfWork
    {

        private readonly NotificationDbContext _context;

        public Ef_UnitOfWork(NotificationDbContext context)
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
