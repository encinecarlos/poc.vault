using Microsoft.AspNetCore.Mvc;

namespace poc.vault.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation($"conf kv: {_configuration["DATABASE-CONNECTION"]}");
            return Ok($"conf kv: {_configuration["DATABASE-CONNECTION"]}");
        }
    }
}
