using Microsoft.EntityFrameworkCore;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.Location.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Persistence.Repositories
{
    public class Ef_AddressRepository : IAddressRepository
    {
        private readonly LocationDbContext _context;

        public Ef_AddressRepository(LocationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Address address, CancellationToken cancellationToken)
        {
            await _context.Addresses.AddAsync(address, cancellationToken);
            return true; // SaveChanges UoW'de yapılacak
        }

        public async Task<Address?> GetByIdAsync(Guid addressId, CancellationToken cancellationToken)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(a => a.Id == addressId, cancellationToken);
        }
    }
}
