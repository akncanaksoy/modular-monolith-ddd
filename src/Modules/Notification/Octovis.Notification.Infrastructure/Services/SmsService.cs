using Octovis.Notification.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            await Task.CompletedTask;
        }
    }
}
