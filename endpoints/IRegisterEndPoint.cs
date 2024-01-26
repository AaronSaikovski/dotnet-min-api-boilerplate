
using Asp.Versioning.Builder;

namespace minapi.boilerplate.endpoints;

/// <summary>
/// Services Endpoint interface
/// </summary>
internal interface IRegisterEndpoint
{
    static abstract void RegisterEndpoint(IEndpointRouteBuilder app, ApiVersionSet versionSet);
}
