using Microsoft.AspNetCore.Mvc;

namespace SwaggerMultiVersion.Controllers;

[ApiController]
[Route("[controller]")]
public class XYZController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<XYZController> _logger;

    public XYZController(ILogger<XYZController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast2")]
    [ApiVersion("1.0")]
    public IEnumerable<WeatherForecast> GetV1()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet(Name = "GetWeatherForecast2")]
    [ApiVersion("2.0")]
    public IEnumerable<WeatherForecast> GetV2()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = $"V2 {Summaries[Random.Shared.Next(Summaries.Length)]}"
        })
        .ToArray();
    }
}
