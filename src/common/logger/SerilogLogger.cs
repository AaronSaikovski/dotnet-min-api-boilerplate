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

using Serilog;

namespace minapi.boilerplate.common.logger;

/// <summary>
/// Implements logging via Serilog
/// </summary>
#pragma warning disable S3881
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
        GC.SuppressFinalize(_logger);
    }
    
    
    
}