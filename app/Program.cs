
using dotnet_minapi_boilerplate.common.logger;
using dotnet_minapi_boilerplate.common.config;
using dotnet_minapi_boilerplate.extensions;
using dotnet_minapi_boilerplate.endpoints;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Diagnostics;
using Asp.Versioning;


//Get timestamp
var startTime = Stopwatch.GetTimestamp();

//Init the logger and get the active config
var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);



//Sample logger usage - https://github.com/serilog/serilog-aspnetcore
try
{
    logger.LogInformation("Starting web application");   
 

    //Create the builder
    var builder = WebApplication.CreateBuilder(args);
    builder.RegisterServices();
    builder.Services.AddApiVersioning();
    builder.Services.AddHealthChecks();
    var app = builder.Build();


    //Create a new API Version Set..for versioning the APIs
    var versionSet = app.NewApiVersionSet()
                        .HasApiVersion(new ApiVersion(1.0))
                        .HasApiVersion(new ApiVersion(2.0))
                        .ReportApiVersions()
                        .Build();

    app.RegisterMiddleware();

    //Add the endpoint, passing the API VersionSet
    PingEndpoint.RegisterEndpoints(app, versionSet);
    WeatherEndpoint.RegisterEndpoints(app, versionSet);
    
    //Add health checks - ref: https://www.milanjovanovic.tech/blog/health-checks-in-asp-net-core
    app.MapHealthChecks(
        "/health",
        new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });


    //get lifetime
    var lifetime= app.Services.GetRequiredService<IHostApplicationLifetime>();
    
    //register the delegate and record elapsed time
    lifetime.ApplicationStarted.Register(() =>
    {
        Console.WriteLine("Startup time: " + Stopwatch.GetElapsedTime(startTime).TotalMilliseconds + "ms");
    });


    app.Run();
}
catch (Exception ex)
{
    logger.LogFatal(ex, "Application terminated unexpectedly");
}
finally
{
    logger.Dispose();
}