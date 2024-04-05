using Serilog;

namespace minapi.boilerplate.common.logger;

/// <summary>
/// Implements logging via Serilog
/// </summary>
public class SerilogLogger : ILoggerService,IDisposable
{
    private readonly Serilog.Core.Logger _logger;

    /// <summary>
    /// Pass in Appsettings config
    /// </summary>
    /// <param name="configuration"></param>
    public SerilogLogger(IConfiguration configuration)
    {
        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration) // Load configuration settings
            .CreateLogger();
        
    }
    
    /// <summary>
    /// LogInformation
    /// </summary>
    /// <param name="message"></param>
    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="message"></param>
    public void LogWarning(string message)
    {
        _logger.Warning(message);
        
    }

    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogError(Exception ex, string message)
    {
        _logger.Error(ex, message);
    }

    /// <summary>
    /// LogVerbose
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogVerbose(Exception ex, string message)
    {
        _logger.Verbose(ex, message);
    }
    
    /// <summary>
    /// fatal
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogFatal(Exception ex, string message)
    {
        _logger.Fatal(ex, message);
    }
    
    /// <summary>
    /// cleanup
    /// </summary>
    public void Dispose()
    {
        _logger.DisposeAsync();
        //Log.CloseAndFlush();
    }
    
}