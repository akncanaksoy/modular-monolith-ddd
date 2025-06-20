using MediatR;
using Octovis.Notification.Application.DTOs;
using Octovis.Notification.Application.Interfaces.Repositories;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Queries.GetPendingStatusNotification
{
    public class GetNotificationStatusPendingHandler : IRequestHandler<GetNotificationPendingStatusQuery, GetNotificationPendingStatusResponse>
    {

        private readonly INotificationRequestRepository _repository;
            
        public GetNotificationStatusPendingHandler(INotificationRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetNotificationPendingStatusResponse> Handle(GetNotificationPendingStatusQuery request, CancellationToken cancellationToken)
        {
            var pendingNotifications = await _repository.GetPendingAsync(cancellationToken);

            List<NotificationRequestDto> dtoList = new();


            foreach (var item in pendingNotifications)
            {
                NotificationRequestDto dto = item switch
                {
                    NotificationRequestEmail email => new NotificationRequestEmailDto
                    {
                        Id = email.Id,
                        NotificationType = NotificationType.Email,
                        Status = email.Status,
                        RetryCount = email.RetryCount,
                        MaxRetry = email.MaxRetry,
                        SentAt = email.SentAt,
                        ProcessedAt = email.ProcessedAt,
                        EmailTo = email.EmailTo,
                        Subject = email.Subject,
                        Body = email.Body
                    },

                    NotificationRequestSms sms => new NotificationRequestSmsDto
                    {
                        Id = sms.Id,
                        NotificationType = NotificationType.Sms,
                        Status = sms.Status,
                        RetryCount = sms.RetryCount,
                        MaxRetry = sms.MaxRetry,
                        SentAt = sms.SentAt,
                        ProcessedAt = sms.ProcessedAt,
                        PhoneNumber = sms.PhoneNumber,
                        Message = sms.Message
                    },

                    _ => throw new InvalidOperationException($"Unsupported notification type: {item.GetType().Name}")
                };

                dtoList.Add(dto);
            }


            return new GetNotificationPendingStatusResponse
            {
                Notifications = dtoList
            };

        }
    }
}
