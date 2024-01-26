

using Asp.Versioning.Builder;
namespace minapi.boilerplate.endpoints;


internal sealed class PingEndpoint : IRegisterEndpoint
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
   /// <summary>
   /// 
   /// </summary>
   /// <param name="app"></param>
   /// <param name="versionSet"></param>
   public static void RegisterEndpoint(IEndpointRouteBuilder app, ApiVersionSet versionSet)
    {        
        // get  http://localhost:<PORT>/api/ping?api-version=1.0
        //Ping -> Pong
        app.MapGet("/api/ping", () =>
                "pong-v1"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0)
            .WithName("ping-v1")
            .WithOpenApi();


        // get  http://localhost:<PORT>>/ping?api-version=2.0
        app.MapGet("/api/ping", () =>
                "pong-v2"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(2.0)
            .WithName("ping-v2")
            .WithOpenApi();

    }
}