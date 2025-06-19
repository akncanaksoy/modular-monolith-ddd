using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Octovis.Notification.Application.UseCases.Commands.SendNotification;
using Octovis.Notification.Application.UseCases.Queries.GetNotifications;


namespace Octovis.Notification.Infrastructure.BackgroundJobs
{
    public class DestroyerJobs : BackgroundService
    {
        private readonly ILogger<DestroyerJobs> _logger;
        private readonly IServiceScopeFactory _scopeFactory;


        public DestroyerJobs(ILogger<DestroyerJobs> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var response = await _mediator.Send(new GetNotificationPendingStatusQuery(), stoppingToken);


                    if (response.Notifications == null || !response.Notifications.Any())
                    {
                        _logger.LogInformation("No pending notifications found.");
                        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                        continue;
                    }

                    _logger.LogInformation("Found {count} pending notifications.", response.Notifications.Count);

                    var tasks = new List<Task>();


                    foreach (var notification in response.Notifications)
                    {
                        tasks.Add(Task.Run(async () =>
                        {

                            try
                            {
                                await _mediator.Send(new SendNotificationCommand(notification), stoppingToken);
                            }
                            catch (Exception ex)
                            {

                                _logger.LogInformation(ex, ex.Message);

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

    }
}
