namespace FusionCacheShared
{
    public record CacheData
    {
        public int Number { get; set; } = new Random().Next(0, 1000);
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}