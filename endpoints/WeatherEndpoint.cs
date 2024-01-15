
using Asp.Versioning.Builder;


namespace minapi.boilerplate.endpoints;

public sealed class WeatherEndpoint : IRegisterEndpoints
{

    /// <summary>
    /// WeatherForecast
    /// </summary>
    /// <param name="Date"></param>
    /// <param name="TemperatureC"></param>
    /// <param name="Summary"></param>
    private record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="versionSet"></param>
     public static void RegisterEndpoints(IEndpointRouteBuilder app, ApiVersionSet versionSet)
    {
        
        //Sample weatherforecast
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //Gets the weather forecast
        //get http://localhost:<PORT>/api/weatherforecast?api-version=1.0
        app.MapGet("/api/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi()
            .WithApiVersionSet(versionSet)
            .MapToApiVersion( 1.0 );
    }

}
