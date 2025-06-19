using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Notification.Application.Interfaces.Services
{
    public interface ISmsService 
    {
        public Task SendSmsAsync(
            string phoneNumber,
            string message
        );
    }
}
