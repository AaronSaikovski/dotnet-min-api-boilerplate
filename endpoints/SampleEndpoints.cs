namespace dotnet_minapi_boilerplate.endpoints;


public static class SampleEndpoints
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
    /// <summary>
    /// RegisterSampleEndpoints
    /// </summary>
    /// <param name="routes"></param>
    public static void RegisterSampleEndpoints(this IEndpointRouteBuilder routes)
    {
        //set routegroup builder
        var sampleRoutes = routes.MapGroup("/minapi/v1/");
        
        //Ping
        sampleRoutes.MapGet("/ping", () => "pong");
  
        
        //Sample weatherforecast
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        sampleRoutes.MapGet("/weatherforecast", () =>
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
            .WithOpenApi();
    }
    
    private record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}