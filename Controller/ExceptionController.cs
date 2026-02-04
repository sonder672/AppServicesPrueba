namespace StressApi.Controller;

public static class ExceptionController
{
    public static void MapExceptionController(this RouteGroupBuilder app)
    {
        app.MapGet("/exception/controlled", (ILogger<Program> logger) =>
        {
            try
            {
                throw new Exception("Soy una excepción malvada");
            } catch (Exception exception)
            {
                logger.LogError($"Ocurrió una excepción: {exception.Message}");
                return Results.InternalServerError();
            }
        });

        app.MapGet("/exception", (ILogger<Program> logger) =>
        {
            throw new Exception("Soy una excepción malvada");
        });
    }
}
