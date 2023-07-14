namespace FusionCacheShared
{
    public static class Constants
    {
        public const string RedisConnectionString = "127.0.0.1:6379,password=p@ssw0rd";
        public const string CacheKey = "MyCacheKey";
        public static readonly TimeSpan CacheDefaultDuration  = TimeSpan.FromMinutes(10);
    }
}