

using Asp.Versioning.Builder;
namespace dotnet_minapi_boilerplate.endpoints;


public class PingEndpoint : IRegisterEndpoints
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
    /// <summary>
    /// RegisterEndpoint
    /// </summary>
    /// <param name="routes"></param>
   public static void RegisterEndpoints(IEndpointRouteBuilder routes, ApiVersionSet versionSet)
    {        
        // get  http://localhost:<PORT>>/ping?api-version=1.0
        //Ping -> Pong
        routes.MapGet( "/ping", () => 
        "pong"
        )
        .WithApiVersionSet(versionSet)
        .MapToApiVersion(1.0);


        // get  http://localhost:<PORT>>/ping?api-version=2.0
        //Ping -> Pong
        routes.MapGet( "/ping", () => 
        "pong-v2"
        )
        .WithApiVersionSet(versionSet)
        .MapToApiVersion(2.0);
 
    }
}