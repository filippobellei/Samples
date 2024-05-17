using StackExchange.Redis;

namespace DistributedCacheSample.Config;

public static class DistributedCacheConfig
{
    public static void AddDistributedCache(this WebApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.ConfigurationOptions = new ConfigurationOptions
            {
                EndPoints = { { "localhost", 6379 } },
                Password = builder.Configuration.GetValue<string>("DistributedCache:Password")
            };
        });
    }
}