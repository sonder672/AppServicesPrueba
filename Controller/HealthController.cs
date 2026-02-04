namespace StressApi.Controller;

public static class HealthController
{
    public static void MapHealthController(this RouteGroupBuilder app)
    {
        app.MapGet("/health", (ILogger<Program> logger) =>
        {
            logger.LogInformation("Health check called");
            return Results.Ok(new
            {
                status = "Healthy",
                time = DateTime.UtcNow
            });
        });
    }
}
