using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly IHostEnvironment _env;
        public WebApiController(IHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok($"Os serviços estão ONLINE em {_env.EnvironmentName}");
        }
    }
}
