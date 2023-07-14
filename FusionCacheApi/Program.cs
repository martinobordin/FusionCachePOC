using FusionCacheApi.Services;
using FusionCacheShared;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion.Serialization.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDataService, DataService>();

//////// REGISTER REDIS AS A DISTRIBUTED CACHE
////builder.Services.AddStackExchangeRedisCache(options =>
////{
////    options.Configuration = Constants.RedisConnectionString;
////});

////// REGISTER THE FUSION CACHE SERIALIZER
////builder.Services.AddFusionCacheNewtonsoftJsonSerializer();

////// REGISTER FUSION CACHE
////builder.Services.AddFusionCache(options => {
////    options.DefaultEntryOptions = new FusionCacheEntryOptions
////    {
////        Duration = Constants.CacheDefaultDuration,
////        Priority = CacheItemPriority.Low
////    };


////});

////// REGISTER THE FUSION CACHE BACKPLANE
////builder.Services.AddFusionCacheStackExchangeRedisBackplane(options => {
////    options.Configuration = Constants.RedisConnectionString;
////});

builder.Services
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
