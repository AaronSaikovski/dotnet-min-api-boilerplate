namespace dotnet_minapi_boilerplate.middleware;

//Ref: https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/

public class ApiKeyMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context) {
        if (!context.Request.Headers.TryGetValue("XApiKey", out
                var extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided ");
            return;
        }
        var appSettings = context.RequestServices.GetRequiredService < IConfiguration > ();
        var apiKey = appSettings.GetValue < string > ("XApiKey");
        if (apiKey is not null && !apiKey.Equals(extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized API Request.");
            return;
        }
        await next(context);
    }
}