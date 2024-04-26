using Hangfire;

namespace HangfireSample.Api.Jobs.Exception;

public static class ExceptionJobEndpoint
{
    public static IResult AddExceptionJobEndpoint()
    {
        BackgroundJob.Enqueue(() => ExceptionJobExample());
        return Results.Ok();
    }

    [AutomaticRetry(Attempts = 1)]
    public static void ExceptionJobExample()
    {
        throw new System.Exception();
    }
}