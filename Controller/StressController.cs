using StressApi.Services;

namespace StressApi.Controller;

public static class StressController
{
    public static void MapStressController(this RouteGroupBuilder app)
    {
        app.MapGet("/stress/cpu", (
            StressService stress,
            ILogger<Program> logger) =>
        {
            logger.LogWarning("CPU stress started");

            stress.StressCpu(TimeSpan.FromSeconds(20));

            logger.LogWarning("CPU stress finished");
            return Results.Ok("CPU stress completed");
        });

        app.MapGet("/stress/parallel", async (
            StressService stress,
            ILogger<Program> logger) =>
        {
            logger.LogWarning("Parallel stress started");

            await stress.StressCpuParallel(
                workers: 8,
                duration: TimeSpan.FromSeconds(15));

            logger.LogWarning("Parallel stress finished");
            return Results.Ok("Parallel stress completed");
        });
    }
}
