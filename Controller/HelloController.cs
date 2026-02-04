namespace StressApi.Controller;

public static class HelloController
{
    public static void MapHelloController(this RouteGroupBuilder app)
    {
        app.MapGet("/hello/{name}", (string name, ILogger<Program> logger) =>
        {
            logger.LogInformation("Hello called for {Name}", name);
            return Results.Ok($"Hello {name}");
        });
    }
}
