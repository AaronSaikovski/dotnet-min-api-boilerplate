using Asp.Versioning;
using dotnet_minapi_boilerplate.middleware;
using Microsoft.Extensions.Options;


namespace dotnet_minapi_boilerplate.extensions;

//Source: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/

/// <summary>
/// RegisterServices
/// </summary>
public static class Register
{
    #region RegisterServices
    /// <summary>
    /// RegisterServices
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
    #endregion

    /// <summary>
    /// RegisterApiVersions
    /// </summary>
    /// <param name="app"></param>
    public static void RegisterApiVersions(this WebApplication app)
    {
        app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1.0))
                .HasApiVersion(new ApiVersion(2.0))
                .ReportApiVersions()
                .Build();
    }
    

    #region RegisterMiddleware
    /// <summary>
    /// RegisterMiddleware
    /// </summary>
    /// <param name="app"></param>
    public static void RegisterMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
                .UseSwaggerUI();
        }

        app.UseHttpsRedirection(); 
        
        //Uncomment this if using API Key middleware
        //app.UseMiddleware<ApiKeyMiddleware>();
    }
    #endregion
}