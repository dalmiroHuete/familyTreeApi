namespace FamilyTreeApi.Middleware;

public class ClientIdMiddleware
{
    // TODO : MOVE THIS TO SECRET , PARAMETER STORE ETC , THE VALUE IS HARDCODED BECAUSE IS NOT A REAL APP
    private const string ValidClientId = "my-secret-client-id";
    private readonly RequestDelegate _next;
    
    public ClientIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("x-client-id", out var clientId))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Missing x-client-id header.");
            return;
        }

        if (clientId != ValidClientId)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid x-client-id.");
            return;
        }

        await _next(context);
    }
}
