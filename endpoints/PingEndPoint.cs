

using Asp.Versioning.Builder;
namespace minapi.boilerplate.endpoints;


public class PingEndpoint : IRegisterEndpoints
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
   /// <summary>
   /// 
   /// </summary>
   /// <param name="routes"></param>
   /// <param name="versionSet"></param>
   public static void RegisterEndpoints(IEndpointRouteBuilder routes, ApiVersionSet versionSet)
    {        
        // get  http://localhost:<PORT>>/api/ping?api-version=1.0
        //Ping -> Pong
        routes.MapGet("/api/ping", () =>
                "pong-v1"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0)
            .WithName("ping-v1")
            .WithOpenApi();


        // get  http://localhost:<PORT>>/ping?api-version=2.0
        routes.MapGet("/api/ping", () =>
                "pong-v2"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(2.0)
            .WithName("ping-v2")
            .WithOpenApi();

    }
}