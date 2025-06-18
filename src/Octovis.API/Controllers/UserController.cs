using Microsoft.AspNetCore.Mvc;

namespace Octovis.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetUsers http request");
            await Task.Delay(100);
            return Ok();
        }
    }

}



