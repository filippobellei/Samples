using StackExchange.Redis;

namespace DistributedCacheSample.Config;

public static class DistributedCacheConfig
{
    public static void AddDistributedCache(this WebApplicationBuilder builder)
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { { "localhost", 6379 } },
            Password = builder.Configuration.GetValue<string>("DistributedCache:Password"),
            Ssl = true,
        };
        configurationOptions.CertificateValidation += delegate
        {
            return true;
        };

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.ConfigurationOptions = configurationOptions;
        });
    }
}