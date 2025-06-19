using Microsoft.EntityFrameworkCore;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Infrastructure.Persistence.Context;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.Repositories
{
    public class Ef_LocationUnitOfWork : ILocationUnitOfWork
    {

        private readonly LocationDbContext _context;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public Ef_LocationUnitOfWork(LocationDbContext context, IDomainEventDispatcher domainEventDispatcher)
        {
            _context = context;
            _domainEventDispatcher = domainEventDispatcher;
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

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            // EF SaveChanges vs.
            var res = await _context.SaveChangesAsync(cancellationToken);

            if (res > 0){

                var domainEvents = _context.ChangeTracker
                               .Entries<IAggregateRoot>()
                               .SelectMany(e => e.Entity.DomainEvents)
                           .ToList();

                foreach (var entity in _context.ChangeTracker.Entries<IAggregateRoot>())
                {
                    entity.Entity.ClearDomainEvents();
                }

                await _domainEventDispatcher.DispatchAsync(domainEvents, cancellationToken);
            }

           

            return res;
        }

      
    }
}
