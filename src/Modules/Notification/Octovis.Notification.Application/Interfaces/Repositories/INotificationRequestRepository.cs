using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.Interfaces.Repositories
{
    public interface INotificationRequestRepository
    {
        Task<List<NotificationRequest>> GetPendingAsync(CancellationToken cancellationToken = default);
        Task AddAsync(NotificationRequest request, CancellationToken cancellationToken = default);
        Task UpdateAsync(NotificationRequest request, CancellationToken cancellationToken = default);
        Task<NotificationRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
