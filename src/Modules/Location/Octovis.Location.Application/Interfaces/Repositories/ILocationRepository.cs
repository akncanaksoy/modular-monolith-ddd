using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        public Task<bool> AddAsync(Domain.AggregateModels.Locations.Location location, CancellationToken cancellationToken);
        public Task<Domain.AggregateModels.Locations.Location> GetByIdAsync(Guid locationId, CancellationToken cancellationToken); 
        public Task<Domain.AggregateModels.Locations.Location> GetByParentIdAsync(Guid locationId, CancellationToken cancellationToken); 
    }

}
