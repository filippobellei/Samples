using Hangfire;

namespace HangfireSample.Api.Jobs.Delayed;

public static class DelayedJobEndpoint
{
    public static IResult AddDelayedJobEndpoint()
    {
        BackgroundJob.Schedule(() => DelayedJobExample(), TimeSpan.FromSeconds(5));
        return Results.Ok();
    }

    public static void DelayedJobExample()
    {
        Console.WriteLine($"{DateTime.Now} - DelayedJob");
    }
}