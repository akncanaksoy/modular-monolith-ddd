using Octovis.Notification.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string emailTo, string subject, string body)
        {
            await Task.CompletedTask;
        }
    }
}
