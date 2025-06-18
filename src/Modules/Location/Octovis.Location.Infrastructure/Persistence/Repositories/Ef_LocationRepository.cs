using Microsoft.EntityFrameworkCore;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Domain.AggregateModels.Locations;
using Octovis.Location.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.Repositories
{
   
    public class Ef_LocationRepository : ILocationRepository
    {
        private readonly LocationDbContext _context;

        public Ef_LocationRepository(LocationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Domain.AggregateModels.Locations.Location location, CancellationToken cancellationToken)
        {
            await _context.Locations.AddAsync(location, cancellationToken);
            return true; // SaveChanges UoW'de yapılır
        }

        public async Task<Domain.AggregateModels.Locations.Location?> GetByIdAsync(Guid locationId, CancellationToken cancellationToken)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(l => l.Id == locationId, cancellationToken);
        }

        public async Task<Domain.AggregateModels.Locations.Location?> GetByParentIdAsync(Guid parentId, CancellationToken cancellationToken)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(l => l.ParentId == parentId, cancellationToken);
        }
    }

}
