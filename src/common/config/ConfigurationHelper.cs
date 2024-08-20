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

namespace minapi.boilerplate.common.config;

/// <summary>
/// Services helper..reads from appsettings file per environment
/// </summary>
public static class ConfigurationHelper
{
    #region fields
    
    //API Key
    public static string? DataApiKey { get; set;}
    
    //Active Services
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