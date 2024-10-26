using Hangfire;

namespace HangfireSample.Api.Jobs.InstanceMethod;

public static class InstanceMethodEndpoint
{
    public static IResult AddInstanceMethodEndpoint()
    {
        BackgroundJob.Enqueue<InstanceMethod>(x => x.InstanceMethodJobExample());
        return Results.Ok();
    }
}
