using MediatR;


namespace Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateEmail
{
    public record CreateEmailNotificationRequestsCommand(
    string EmailTo,
    string Subject,
    string Body
) : IRequest<bool>;
}
