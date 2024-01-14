
using Asp.Versioning.Builder;

namespace minapi.boilerplate.endpoints;

/// <summary>
/// Register Endpoint interface
/// </summary>
public interface IRegisterEndpoints
{
    static abstract void RegisterEndpoints(IEndpointRouteBuilder app, ApiVersionSet versionSet);
    
}
