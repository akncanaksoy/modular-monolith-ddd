using MediatR;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateEmail;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands
{
    public class CreateNotificationRequestsHandler : IRequestHandler<CreateEmailNotificationRequestsCommand,bool>
    {
        private readonly INotificationRequestRepository _repository;
        private readonly INotificationUnitOfWork _unitOfWork;

        public CreateNotificationRequestsHandler(INotificationRequestRepository repository, INotificationUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> Handle(CreateEmailNotificationRequestsCommand request, CancellationToken cancellationToken)
        {
            var emailNotification = NotificationRequestEmail.Create(
             emailTo: request.EmailTo,
             subject: request.Subject,
             body: request.Body
         );

            

            await _repository.AddAsync(emailNotification, cancellationToken);

            var res = await _unitOfWork.SaveChangesAsync();

            return res > 0;
        }
    }
}
