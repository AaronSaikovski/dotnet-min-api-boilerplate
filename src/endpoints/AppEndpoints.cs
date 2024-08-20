using Asp.Versioning;

namespace minapi.boilerplate.endpoints;

#pragma warning disable S1118
public sealed class AppEndpoints
#pragma warning restore S1118
{
   

    /// <summary>
    /// RegisterAppEndpoints
    /// </summary>
    /// <param name="app"></param>
    public static void RegisterAppEndpoints(IEndpointRouteBuilder app)
    {
        //Create a new API Version Set..for versioning the APIs
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .HasApiVersion(new ApiVersion(2.0))
            .ReportApiVersions()
            .Build();
        
        //Add the endpoint, passing the API VersionSet
        PingEndpoint.RegisterEndpoint(app, versionSet);
    }
    
}