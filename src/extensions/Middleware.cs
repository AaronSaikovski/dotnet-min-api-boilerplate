

/* Uncomment the line below to add API validation */
//using minapi.boilerplate.middleware;

namespace minapi.boilerplate.extensions;

//Source: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/

/// <summary>
/// RegisterServices
/// </summary>
public static class Middleware
{
   
    /// <summary>
    /// RegisterMiddleware
    /// </summary>   
    public static void RegisterMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        
        /* Uncomment the line below to add API validation */
        // app.UseMiddleware<ApiKeyMiddleware>();

    }
   
}
