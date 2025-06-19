using MediatR;
using Microsoft.AspNetCore.Mvc;
using Octovis.Location.Application.UseCases.Commands.CreateAddress;
using Octovis.Notification.Application.UseCases.Commands.CreateNotification.CreateEmail;

namespace Octovis.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private readonly ILogger<NotificationController> _logger;

        private readonly IMediator _mediator;

        public NotificationController(ILogger<NotificationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost("test-add-notification")]
        public async Task<IActionResult> AddAddress(CreateEmailNotificationRequestsCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }

}



