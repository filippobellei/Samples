using Hangfire;

namespace HangfireSample.Jobs;

public static class RecurringJobs
{
    public static void AddRecurringJobs()
    {
        RecurringJob.AddOrUpdate(
            "RecurringJobExample",
            () => RecurringJobExampleAsync(),
            Cron.Minutely()
        );

        RecurringJob.AddOrUpdate(
            "RecurringJobCRONExample",
            () => RecurringCRONJobExampleAsync(),
            "*/2 * * * *"
        );
    }

    public static Task RecurringJobExampleAsync()
    {
        Console.WriteLine($"{DateTime.Now} - RecurringJob");
        return Task.CompletedTask;
    }

    public static Task RecurringCRONJobExampleAsync()
    {
        Console.WriteLine($"{DateTime.Now} - RecurringCRONJob");
        return Task.CompletedTask;
    }
}