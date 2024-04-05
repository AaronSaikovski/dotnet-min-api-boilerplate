using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace minapi.boilerplate.extensions;

public static class HealthCheck
{
    #region RegisterHealthCheck
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
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
    #endregion
}