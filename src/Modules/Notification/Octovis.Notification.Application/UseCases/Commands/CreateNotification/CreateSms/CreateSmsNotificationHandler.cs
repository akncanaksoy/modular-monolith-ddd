using MediatR;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateSms
{
    public class CreateSmsNotificationHandler : IRequestHandler<CreateSmsNotificationCommand, bool>
    {
        private readonly INotificationRequestRepository _repository;
        private readonly INotificationUnitOfWork _unitOfWork;


        public CreateSmsNotificationHandler(INotificationRequestRepository repository, INotificationUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateSmsNotificationCommand request, CancellationToken cancellationToken)
        {
            var smsNotification = NotificationRequestSms.Create(
                phoneNumber: request.PhoneNumber,
                message: request.Message
                
            );

            await _repository.AddAsync(smsNotification, cancellationToken);

            var res = await _unitOfWork.SaveChangesAsync();

            return res > 0;
        }
    }
}
