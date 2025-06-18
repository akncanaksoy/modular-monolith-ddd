using Octovis.Location.Domain.AggregateModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<bool> AddAsync(Address address,CancellationToken cancellationToken);
        public Task<Address?> GetByIdAsync(Guid addressIdi,CancellationToken cancellationToken);

    }
}
