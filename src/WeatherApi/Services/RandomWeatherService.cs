
namespace WeatherApi.Services;

public class RandomWeatherService : IWeatherService
{
    private static readonly IList<string> ColdAdjectives = new string[] { "Freezing", "Bracing", "Chilly", "Cool" };
    private static string[] Summaries = new string[] { "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public Task<WeatherForecast[]> GetWeatherForecasts()
    {
        Summaries = Summaries.Concat(ColdAdjectives).ToArray();
        var weatherForecasts = Enumerable
            .Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    date: DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    temperatureC: Random.Shared.Next(-20, 55),
                    summary: Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();

        return Task.FromResult(weatherForecasts);
    }
}