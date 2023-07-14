using FusionCacheShared;
using FusionCacheWorker;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion.Serialization.NewtonsoftJson;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        //// REGISTER REDIS AS A DISTRIBUTED CACHE
        ////services.AddStackExchangeRedisCache(options => {
        ////    options.Configuration = Constants.RedisConnectionString;
        ////});

        ////// REGISTER THE FUSION CACHE SERIALIZER
        ////services.AddFusionCacheNewtonsoftJsonSerializer();

        ////// REGISTER FUSION CACHE
        ////services.AddFusionCache(options => {
        ////    options.DefaultEntryOptions = new FusionCacheEntryOptions
        ////    {
        ////        Duration = Constants.CacheDefaultDuration,
        ////        Priority = CacheItemPriority.Low
        ////    };
        ////});

        ////// REGISTER THE FUSION CACHE BACKPLANE
        ////services.AddFusionCacheStackExchangeRedisBackplane(options => {
        ////    options.Configuration = Constants.RedisConnectionString;
        ////});

        services
          .AddFusionCache()
          .WithDefaultEntryOptions(opt =>
          {
              opt.Duration = Constants.CacheDefaultDuration;
              opt.Priority = CacheItemPriority.Low;
          })
          .WithSerializer(new FusionCacheNewtonsoftJsonSerializer())
          .WithDistributedCache(new RedisCache(new RedisCacheOptions
          {
              Configuration = Constants.RedisConnectionString
          }))
          .WithBackplane(new RedisBackplane(new RedisBackplaneOptions
          {
              Configuration = Constants.RedisConnectionString
          }));


    })
    .Build();

await host.RunAsync();
