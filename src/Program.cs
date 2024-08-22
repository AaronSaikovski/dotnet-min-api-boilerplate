/*
MIT License

# Copyright (c) 2024 Aaron Saikovski

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using minapi.boilerplate.common.logger;
using minapi.boilerplate.common.config;
using minapi.boilerplate.extensions;
using minapi.boilerplate.endpoints;
using minapi.boilerplate.exceptions;
using System.Diagnostics;

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;



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
    
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    
    //Setup the builder
    var app = builder.Build();
    
    //add exception handler to the pipeline
    app.UseExceptionHandler();
    
    //Register middleware
    app.RegisterMiddleware();
    
    //Add health checks
    app.RegisterHealthCheck();

    //Add the custom application endpoints
    AppEndpoints.RegisterAppEndpoints(app);

    //Source: https://devblogs.microsoft.com/ise/next-level-clean-architecture-boilerplate/ & https://github.com/dorlugasigal/MiniClean.Template/tree/main
    app.MapHealthChecks("/_health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
    
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