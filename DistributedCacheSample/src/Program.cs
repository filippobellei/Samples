using DistributedCacheSample.Api;
using DistributedCacheSample.Config;

var builder = WebApplication.CreateBuilder();
builder.AddDistributedCache();

var app = builder.Build();
app.MapGet("/time-cached", CacheApi.GetTimeCachedAsync);

app.Run("http://localhost:5000");