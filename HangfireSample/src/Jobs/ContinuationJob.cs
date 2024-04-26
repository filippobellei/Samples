namespace HangfireSample.Jobs;

public sealed class ContinuationJob
{
    public static async Task ContinuationJobExampleAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine($"{DateTime.Now} - ContinuationJob");
    }
}