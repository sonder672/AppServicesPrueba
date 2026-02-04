namespace StressApi.Services;

public class StressService
{
    public void StressCpu(TimeSpan duration)
    {
        var end = DateTime.UtcNow.Add(duration);

        while (DateTime.UtcNow < end)
        {
            Math.Sqrt(Random.Shared.NextDouble());
        }
    }

    public async Task StressCpuParallel(int workers, TimeSpan duration)
    {
        await Task.WhenAll(
            Enumerable.Range(0, workers).Select(_ =>
                Task.Run(() =>
                {
                    var end = DateTime.UtcNow.Add(duration);
                    while (DateTime.UtcNow < end)
                    {
                        Math.Pow(Random.Shared.NextDouble(), 5);
                    }
                })
            )
        );
    }
}
