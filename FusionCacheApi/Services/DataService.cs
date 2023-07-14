using FusionCacheShared;
using ZiggyCreatures.Caching.Fusion;

namespace FusionCacheApi.Services
{
    public interface IDataService
    {
        Task DeleteDataAsync(CancellationToken cancellationToken = default);
        Task<CacheData?> GetDataAsync(CancellationToken cancellationToken = default);
        Task SetDataAsync(CacheData cacheData, CancellationToken cancellationToken = default);
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> logger;
        private readonly IFusionCache cache;

        public DataService(ILogger<DataService> logger, IFusionCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        public async Task<CacheData?> GetDataAsync(CancellationToken cancellationToken = default)
        {
            logger.LogTrace("Called {method}", nameof(GetDataAsync));

            var result = await cache.GetOrDefaultAsync<CacheData>(Constants.CacheKey);
            return result;
        }

        public async Task SetDataAsync(CacheData cacheData, CancellationToken cancellationToken = default)
        {
            logger.LogTrace("Called {method}", nameof(SetDataAsync));

            await cache.SetAsync(Constants.CacheKey, cacheData);
        }

        public async Task DeleteDataAsync(CancellationToken cancellationToken = default)
        {
            logger.LogTrace("Called {method}", nameof(DeleteDataAsync));

            await cache.RemoveAsync(Constants.CacheKey);
        }
    }
}
