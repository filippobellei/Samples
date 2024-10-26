using Hangfire;
using HangfireSample.Jobs;

namespace HangfireSample.Api.Jobs.Manual;

public static class ManualJobEndpoint
{
    public static IResult AddManualJobEndpoint()
    {
        var jobId = BackgroundJob.Enqueue(() => ManualJobExample());
        BackgroundJob.ContinueJobWith(jobId, () => ContinuationJob.ContinuationJobExampleAsync());
        return Results.Ok();
    }

    public static void ManualJobExample()
    {
        Console.WriteLine($"{DateTime.Now} - ManualJob");
    }
}
