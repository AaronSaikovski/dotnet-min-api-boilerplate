
using minapi.boilerplate.common.logger;
using minapi.boilerplate.common.config;
using minapi.boilerplate.extensions;
using minapi.boilerplate.endpoints;

using System.Diagnostics;

//Get timestamp
long startTime;
startTime = Stopwatch.GetTimestamp();

//Init the logger and get the active config
using var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);


//Sample logger usage - https://github.com/serilog/serilog-aspnetcore
try
{
    logger.LogInformation("Starting web application");
    //Create the builder
    var builder = WebApplication.CreateBuilder(args);
    
    //Register services
    builder.RegisterServices();
    
    //Setup the builder
    var app = builder.Build();
    
    //Register middleware
    app.RegisterMiddleware();
    
    //Add health checks
    app.RegisterHealthCheck();

    //add antiforgery to the pipeline
    //app.UseAntiforgery();
    
    //Add the custom application endpoints
    AppEndpoints.RegisterAppEndpoints(app);
    
    //get lifetime
    var lifetime= app.Services.GetRequiredService<IHostApplicationLifetime>();
    
    //register the delegate and record elapsed time
    lifetime.ApplicationStarted.Register(() =>
    {
        Console.WriteLine($"Startup time: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds}ms");
    });

    app.Run();
}
catch (Exception ex)
{
    logger.LogFatal(ex, "Application terminated unexpectedly");
}