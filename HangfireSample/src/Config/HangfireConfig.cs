using Hangfire;
using HangfireSample.Jobs;

namespace HangfireSample.Config;

public static class HangfireConfig
{
    public static void AddHangfire(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(configuration => configuration
            .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"))
        );

        builder.Services.AddHangfireServer();
    }

    public static void UseHangfire(this WebApplication app)
    {
        app.UseHangfireDashboard();
        RecurringJobs.AddRecurringJobs();
    }
}
