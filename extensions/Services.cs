
using Asp.Versioning;
namespace minapi.boilerplate.extensions;

//Source: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/

/// <summary>
/// RegisterServices
/// </summary>
public static class Services
{
    #region RegisterServices
    /// <summary>
    /// RegisterServices
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1.0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("x-version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
   
    }
    #endregion
}