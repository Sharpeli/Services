using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestController : ControllerBase
    {

        private readonly ILogger<RestController> _logger;

        public RestController(ILogger<RestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("greet")]
        public string Greet(string name)
        {
            return $"Hello Rest: {name}";
        }
    }
}
