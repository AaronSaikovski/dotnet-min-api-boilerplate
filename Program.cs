
using dotnet_minapi_boilerplate.common.Logger;
using dotnet_minapi_boilerplate.common.Config;
using dotnet_minapi_boilerplate.extensions;
using dotnet_minapi_boilerplate.endpoints;

//Init the logger and get the active config
var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

//Sample logger usage - https://github.com/serilog/serilog-aspnetcore
try
{
    //logger.LogInformation("Starting web application");
    
    //Create the builder
    var builder = WebApplication.CreateBuilder(args);
    builder.RegisterServices();
    var app = builder.Build();
    app.RegisterMiddleware();
    app.RegisterSampleEndpoints();
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