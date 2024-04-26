using HangfireSample.Api.Jobs.Delayed;
using HangfireSample.Api.Jobs.Exception;
using HangfireSample.Api.Jobs.InstanceMethod;
using HangfireSample.Api.Jobs.Manual;

namespace HangfireSample.Api.Jobs;

public static class JobsApi
{
    public static RouteGroupBuilder MapJobsApi(this RouteGroupBuilder group)
    {
        group.MapGet("/manual", ManualJobEndpoint.AddManualJobEndpoint);
        group.MapGet("/delayed", DelayedJobEndpoint.AddDelayedJobEndpoint);
        group.MapGet("/exception", ExceptionJobEndpoint.AddExceptionJobEndpoint);
        group.MapGet("/instanceMethod", InstanceMethodEndpoint.AddInstanceMethodEndpoint);

        return group;
    }
}