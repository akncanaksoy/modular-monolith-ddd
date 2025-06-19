using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Octovis.Notification.Application.UseCases.Queries;
using Octovis.Notification.Application.UseCases.Queries.GetNotifications;
using Octovis.Notification.Domain.AggregateModels.NotificationRequests;
using System.Collections.Concurrent;

namespace Octovis.Notification.Destroyer
{
    public class DestroyerWorker : BackgroundService
    {
        private readonly ILogger<DestroyerWorker> _logger;
        private readonly IMediator _mediator;

        public DestroyerWorker(ILogger<DestroyerWorker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background service started.");

             while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var response = await _mediator.Send(new GetNotificationPendingStatusQuery(), stoppingToken);

                    if (response.Notifications == null || !response.Notifications.Any())
                    {
                        _logger.LogInformation("No pending notifications found.");
                        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                        continue;
                    }

                    _logger.LogInformation("Found {count} pending notifications.", response.Notifications.Count);

                    var tasks = new List<Task>();
                    var failedNotifications = new ConcurrentBag<NotificationRequest>();

                    foreach (var notification in response.Notifications)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            try
                            {
                                // Burada tipine göre işlem yapılır
                                switch (notification.NotificationType)
                                {
                                    case NotificationType.Email:
                                        // Email gönderme servisi burada kullanılabilir
                                        _logger.LogInformation("Sending email to {email}", email.EmailTo);
                                        await SendEmailAsync(email); // burayı senin gerçek servisinle değiştir
                                        break;

                                    case NotificationType.Sms:
                                        _logger.LogInformation("Sending sms to {number}", sms.PhoneNumber);
                                        await SendSmsAsync(sms); // burayı senin gerçek servisinle değiştir
                                        break;

                                    default:
                                        _logger.LogWarning("Unsupported notification type.");
                                        return;
                                }

                                await _mediator.Send(new UpdateNotificationStatusCommand(notification.Id, NotificationStatus.Completed), stoppingToken);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to send notification with Id: {id}", notification.Id);
                                failedNotifications.Add(notification);

                                // retry sayısı artışı gibi işlemler yapılabilir
                                await _mediator.Send(new UpdateNotificationStatusCommand(notification.Id, NotificationStatus.Failed), stoppingToken);
                            }
                        }, stoppingToken));
                    }

                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred in DestroyerWorker.");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            _logger.LogInformation("Notification DestroyerWorker stopped.");
        }

        private async Task SendEmailAsync(NotificationRequestEmail email)
        {
            // Email gönderme işlemi burada yapılmalı.
            await Task.Delay(300); // Simülasyon
        }

        private async Task SendSmsAsync(NotificationRequestSms sms)
        {
            // SMS gönderme işlemi burada yapılmalı.
            await Task.Delay(300); // Simülasyon
        }




    }
}

