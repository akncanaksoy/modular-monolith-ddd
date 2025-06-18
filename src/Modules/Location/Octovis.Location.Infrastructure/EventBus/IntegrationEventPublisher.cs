using MediatR;
using Microsoft.Extensions.Logging;
using Octovis.Location.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.EventBus
{
    public class IntegrationEventPublisher : IIntegrationEventPublisher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IntegrationEventPublisher> _logger;

        public IntegrationEventPublisher(IMediator mediator, ILogger<IntegrationEventPublisher> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default)
            where TEvent : INotification
        {
            _logger.LogInformation("Publishing integration event: {EventType}", typeof(TEvent).Name);

            await _mediator.Publish(integrationEvent, cancellationToken);

            _logger.LogInformation("Integration event published: {EventType}", typeof(TEvent).Name);
        }
    }
}
