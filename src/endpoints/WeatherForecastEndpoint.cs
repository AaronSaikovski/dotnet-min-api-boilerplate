using Carter;
using System.Security.Cryptography;

namespace minapi.boilerplate.endpoints;

public sealed class WeatherForecastEndpoint : ICarterModule
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            RandomNumberGenerator.GetInt32(-20, 55),
                            Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");
    }
}

internal sealed record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
