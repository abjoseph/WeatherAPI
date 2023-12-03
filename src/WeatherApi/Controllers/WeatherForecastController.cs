using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    // public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger, )
    public WeatherForecastController([FromKeyedServices("api")] IWeatherService weatherService, ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
    // [ProducesResponseType<WeatherForecast>(StatusCodes.Status200OK)]
    public Task<WeatherForecast[]> Get()
    {
        return _weatherService.GetWeatherForecasts();
    }
}
