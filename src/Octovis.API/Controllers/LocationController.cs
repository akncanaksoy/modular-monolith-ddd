using MediatR;
using Microsoft.AspNetCore.Mvc;
using Octovis.Location.Application.UseCases.Commands.AssignUserToLocation;
using Octovis.Location.Application.UseCases.Commands.CreateAddress;
using Octovis.Location.Application.UseCases.Commands.CreateLocation;
using Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateArea;
using Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateCompany;
using Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateDealer;
using Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateRegion;

namespace Octovis.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;

        private readonly IMediator _mediator;

        public LocationController(ILogger<LocationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetLocation")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetLocation http request");
            await Task.Delay(100);
            return Ok();
        }


        [HttpPost("assign-user-to-location")]
        public async Task<IActionResult> AssignUserToLocation(AssignUserToLocationCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("add-address")]
        public async Task<IActionResult> AddAddress(AddAddressCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }



        [HttpPost("create-area")]
        public async Task<IActionResult> CreateArea(CreateAreaCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("create-company")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("create-dealer")]
        public async Task<IActionResult> CreateDealer(CreateDealerCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("create-region")]
        public async Task<IActionResult> CreateRegion(CreateRegionCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("create-location")]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


    }
}
