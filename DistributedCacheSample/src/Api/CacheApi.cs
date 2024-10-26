using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCacheSample.Api;

public static class CacheApi
{
    public static async Task<IResult> GetTimeCachedAsync(IDistributedCache cache)
    {
        var cachedValue = await cache.GetStringAsync("time");

        if (cachedValue is null)
        {
            cachedValue = DateTime.UtcNow.ToString();

            await cache.SetStringAsync("time", cachedValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
            });
        }

        return Results.Ok(cachedValue);
    }
}
