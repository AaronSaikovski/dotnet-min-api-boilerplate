using Carter;
using minapi.boilerplate.common.logger;
using minapi.boilerplate.common.config;
using minapi.boilerplate.extensions;
using minapi.boilerplate.exceptions;


//Init the logger and get the active config
using var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

//Sample logger usage - https://github.com/serilog/serilog-aspnetcore
logger.LogInformation("Starting web application");

//Create the builder
var builder = WebApplication.CreateBuilder(args);

// builder.Configuration(config =>
// {
//     // Environment variables come from:
//     //   - Azure App Config
//     //   - Portal "Configuration"
//     //   - local.settings.json (local only)
//     config.AddEnvironmentVariables();
//     config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
// });

//Register services
builder.RegisterServices();

// Add Carter module discovery
builder.Services.AddCarter();

// Add OpenAPI support
builder.Services.AddOpenApi();

// Add global exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Create and bind SharedConfig from appsettings
var sharedConfig = new SharedConfig
{
    SampleConfig = builder.Configuration["SampleValue:SampleSetting"] ?? string.Empty,
};
builder.Services.AddSingleton(sharedConfig);

//Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//add exception handler to the pipeline
app.UseExceptionHandler();

//Register middleware
app.RegisterMiddleware();

//Add health checks
app.RegisterHealthCheck();

//Map Carter modules - auto-discovers all ICarterModule implementations
app.MapCarter();

app.Run();
