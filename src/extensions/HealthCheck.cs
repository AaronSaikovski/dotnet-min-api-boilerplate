

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace minapi.boilerplate.extensions;

public static class HealthCheck
{

    /// <summary>
    /// register health checks
    /// </summary>
    public static void RegisterHealthCheck(this WebApplication app)
    {
        //Add health checks - ref: https://www.milanjovanovic.tech/blog/health-checks-in-asp-net-core
        app.MapHealthChecks(
            "/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
    }
 
}
