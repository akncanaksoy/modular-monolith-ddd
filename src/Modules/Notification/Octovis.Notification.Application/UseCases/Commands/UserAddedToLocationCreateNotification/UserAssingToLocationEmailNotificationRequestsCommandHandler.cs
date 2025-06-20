using MediatR;
using Octovis.Notification.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.UseCases.Commands.UserAddedToLocationCreateNotification
{
    public class UserAssingToLocationEmailNotificationRequestsCommandHandler : IRequestHandler<UserAssingToLocationEmailNotificationRequestsCommand, bool>
    {
        private readonly ITemplateGenerator _templateGenerator;

        public UserAssingToLocationEmailNotificationRequestsCommandHandler(ITemplateGenerator templateGenerator)
        {

            _templateGenerator = templateGenerator ?? throw new ArgumentNullException(nameof(templateGenerator));
        }
        public Task<bool> Handle(UserAssingToLocationEmailNotificationRequestsCommand request, CancellationToken cancellationToken)
        {

            _templateGenerator.Generate();

            throw new Exception();
            


        }
    }
}
