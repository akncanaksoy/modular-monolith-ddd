using MediatR;
using Octovis.Location.Contract.IntegrationEvents;
using Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateEmail;
using Octovis.Notification.Application.UseCases.Commands.UserAddedToLocationCreateNotification;


namespace Octovis.Notification.Application.EventHandlers.IntegrationEventHandlers
{
    public class UserAssignedToLocationIntegrationEventHandler : INotificationHandler<UserAssignedToLocationIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public UserAssignedToLocationIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(UserAssignedToLocationIntegrationEvent @event, CancellationToken cancellationToken)
        {

            var command = new UserAssingToLocationEmailNotificationRequestsCommand(

               @event.UserId, @event.LocationId
            );

            await _mediator.Send(command, cancellationToken);
        }
    }
}
