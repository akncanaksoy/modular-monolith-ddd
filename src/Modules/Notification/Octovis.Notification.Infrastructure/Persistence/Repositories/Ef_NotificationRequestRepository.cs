using Microsoft.EntityFrameworkCore;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using Octovis.Notification.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Persistence.Repositories
{
    public class Ef_NotificationRequestRepository : INotificationRequestRepository
    {
        private readonly NotificationDbContext _context;

        public Ef_NotificationRequestRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationRequest>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRequests
                .Where(r => r.Status == NotificationStatus.Pending)
                .Include(r => r.Logs)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(NotificationRequest request, CancellationToken cancellationToken = default)
        {
            await _context.NotificationRequests.AddAsync(request, cancellationToken);
        }

        public async Task UpdateAsync(NotificationRequest request, CancellationToken cancellationToken = default)
        {
            _context.NotificationRequests.Update(request);
            await Task.CompletedTask;
        }

        public async Task<NotificationRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRequests
                .Include(r => r.Logs)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }
    }
}
