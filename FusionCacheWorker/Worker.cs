using FusionCacheShared;
using ZiggyCreatures.Caching.Fusion;

namespace FusionCacheWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IFusionCache cache;

        public Worker(ILogger<Worker> logger, IFusionCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cachedEntry = this.cache.TryGet<CacheData>(Constants.CacheKey);
                if (cachedEntry.HasValue)
                {
                    this.logger.LogInformation("Value retrieved from cache {key}: {value}", Constants.CacheKey, cachedEntry.Value);
                }
                else
                {
                    this.logger.LogInformation("Value NOT retrieved from cache {key}", Constants.CacheKey);
                }
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}