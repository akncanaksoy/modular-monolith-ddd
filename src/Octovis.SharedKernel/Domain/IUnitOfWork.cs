using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.SharedKernel.Domain
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
