using Microsoft.Extensions.Configuration;

namespace dotnet_minapi_boilerplate.common.Config;

/// <summary>
/// Configuration helper..reads from appsettings file per environment
/// </summary>
public static class ConfigurationHelper
{
    #region fields
    
    //API Key
    public static string? DataApiKey { get; }
    
    //Active Configuration
    public static IConfiguration ActiveConfiguration { get; }
    
    #endregion

    #region ConfigurationHelper
    /// <summary>
    /// Config helper
    /// </summary>
    static ConfigurationHelper()
    {
        //Toggle if DEBUG flag set
        #if DEBUG
                                
                //Load config - DEBUG
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
        #else
                       
                //Load config - RELEASE
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
        #endif
            
            
        //Set the active configuration
        ActiveConfiguration = configuration;
        
        //Auth Key
        DataApiKey = configuration.GetSection("DataAPISvc")["XApiKey"];
    }
    #endregion
    
  
  
}