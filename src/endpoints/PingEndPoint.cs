

using Asp.Versioning;
using Carter;

namespace minapi.boilerplate.endpoints;

public sealed class PingEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .HasApiVersion(new ApiVersion(2.0))
            .ReportApiVersions()
            .Build();

        // get  http://localhost:<PORT>/api/ping?api-version=1.0
        //Ping -> Pong
        app.MapGet("/api/ping", () =>
                "pong-v1"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0)
            .WithName("ping-v1");

        // get  http://localhost:<PORT>/api/ping?api-version=2.0
        app.MapGet("/api/ping", () =>
                "pong-v2"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(2.0)
            .WithName("ping-v2");
    }
}
