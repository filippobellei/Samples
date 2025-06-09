using System.Security.Cryptography;

namespace StreamSample.Endpoints;

public static class StreamEndpoints
{
    public static void MapStreamEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("streamTextSimulator", (IConfiguration configuration) =>
        {
            async IAsyncEnumerable<string> StreamTextSimulator()
            {
                var text = configuration["Text"]!.Split(' ');

                foreach (var word in text)
                {
                    await Task.Delay(RandomNumberGenerator.GetInt32(500, 1250));
                    yield return word + " ";
                }
            }

            return StreamTextSimulator();
        });
    }
}
