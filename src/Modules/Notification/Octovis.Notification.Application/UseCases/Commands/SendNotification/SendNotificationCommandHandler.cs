using MediatR;
using Microsoft.Extensions.Logging;
using Octovis.Notification.Application.DTOs;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.SendNotification
{
    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly INotificationRequestRepository _repository;
        private readonly INotificationUnitOfWork _unitOfWork;

        public SendNotificationCommandHandler(
            IEmailService emailService,
            ISmsService smsService,
            INotificationRequestRepository repository)
        {
            _emailService = emailService;
            _smsService = smsService;
            _repository = repository;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _repository.GetByIdAsync(request.Notification.Id);

            if (notification == null || !notification.CanBeSent())
                throw new InvalidOperationException("Notification cannot be sent or has already been sent.");

            try
            {
                switch (request.Notification)
                {
                    case NotificationRequestEmailDto email:
                        await _emailService.SendEmailAsync(email.EmailTo, email.Subject, email.Body);
                        notification.MarkAsSent();
                        break;
                    case NotificationRequestSmsDto sms:
                        await _smsService.SendSmsAsync(sms.PhoneNumber, sms.Message);
                        notification.MarkAsSent();
                        break;
                }
            }

            catch
            {
                notification.MarkAsFailed();
            }

            await _repository.UpdateAsync(notification);

            await _unitOfWork.SaveChangesAsync();

        }
    }

}
