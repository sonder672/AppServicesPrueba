namespace StressApi.Util;

public static class EndpointExtensions
{
    public static RouteGroupBuilder MapApi(this WebApplication app)
    {
        return app.MapGroup("/api")
                  .RequireAuthorization();
    }
}
