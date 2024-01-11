

namespace minapi.boilerplate.common.config;

/// <summary>
/// Register helper..reads from appsettings file per environment
/// </summary>
public static class ConfigurationHelper
{
    #region fields
    
    //API Key
    public static string? DataApiKey { get; set;}
    
    //Active Register
    public static IConfiguration ActiveConfiguration { get; set;}
    
    #endregion

    #region ConfigurationHelper
    /// <summary>
    /// config helper
    /// </summary>
    static ConfigurationHelper()
    {
        //Toggle if DEBUG flag set
 //Load config - DEBUG
        var configuration = new ConfigurationBuilder()                    
            .AddEnvironmentVariables()                   
        #if DEBUG 
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)            
        #else
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        #endif
        .Build();
            
            
        //Set the active configuration
        ActiveConfiguration = configuration;
        
        //Auth Key
        DataApiKey = configuration.GetSection("DataAPISvc")["XApiKey"];
    }
    #endregion
    
  
  
}