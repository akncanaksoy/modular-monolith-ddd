using MediatR;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands
{
    public class CreateNotificationRequestsHandler : IRequestHandler<CreateNotificationRequestsCommand>
    {
        private readonly INotificationRequestRepository _repository;

        public CreateNotificationRequestsHandler(INotificationRequestRepository repository)
        {
            _repository = repository;
        }

        

        public async Task Handle(CreateNotificationRequestsCommand request, CancellationToken cancellationToken)
        {
            var emailRequest = new NotificationRequestEmail(
                request.EmailTo,
                request.Subject,
                request.Body,
                request.MaxRetry
            );

            await _repository.AddAsync(emailRequest, cancellationToken);

        }
    }
}
