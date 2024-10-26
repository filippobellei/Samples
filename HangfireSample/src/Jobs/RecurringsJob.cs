using Hangfire;

namespace HangfireSample.Jobs;

public static class RecurringJobs
{
    public static void AddRecurringJobs()
    {
        RecurringJob.AddOrUpdate(
            "RecurringJobExample",
            () => RecurringJobExample(),
            Cron.Minutely()
        );

        RecurringJob.AddOrUpdate(
            "RecurringJobCRONExample",
            () => RecurringCRONJobExample(),
            "*/2 * * * *"
        );
    }

    public static void RecurringJobExample()
    {
        Console.WriteLine($"{DateTime.Now} - RecurringJob");
    }

    public static void RecurringCRONJobExample()
    {
        Console.WriteLine($"{DateTime.Now} - RecurringCRONJob");
    }
}
