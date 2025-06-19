using MediatR;


namespace Octovis.Notification.Application.UseCases.Commands
{
    public record CreateNotificationRequestsCommand(
    string EmailTo,
    string Subject,
    string Body,
    int MaxRetry
) : IRequest;
}
