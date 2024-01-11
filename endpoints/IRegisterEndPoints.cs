
using Asp.Versioning.Builder;

namespace dotnet_minapi_boilerplate.endpoints;

/// <summary>
/// Register Endpoint interface
/// </summary>
public interface IRegisterEndpoints
{
    abstract static void RegisterEndpoints(IEndpointRouteBuilder app, ApiVersionSet versionSet);
    
}
