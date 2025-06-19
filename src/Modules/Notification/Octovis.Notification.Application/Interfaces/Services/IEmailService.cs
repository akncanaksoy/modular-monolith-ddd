using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(
            string emailTo,
            string subject,
            string body
        );

    }
}
