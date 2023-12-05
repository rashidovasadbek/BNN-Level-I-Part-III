using Cashing.Infra.Infrastructure.Common.Settings;
using Cashing.Infra.Persistence.cashing;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Cashing.Infra.Infrastructure.Common.Cashing;

public class LazyMemoryCacheBroker(IAppCache appCache, IOptions<CacheSettings> cacheSettings) : ICacheBroker
{

    private readonly CacheSettings _cacheSettings = cacheSettings.Value;

    public async ValueTask<T> GetAsync<T>(string key) => await appCache.GetAsync<T>(key);

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_cacheSettings.AbsoluteExpirationInMinutes),
            SlidingExpiration = TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationInMinutes)
        };

        return await appCache.GetOrAddAsync(key, valueFactory, options);
    }

    public ValueTask SetASync<T>(string key, T value)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes((_cacheSettings.AbsoluteExpirationInMinutes)),
            SlidingExpiration = TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationInMinutes)
        };
        
        appCache.Add(key, value, options);
        
        return ValueTask.CompletedTask;
    }

    public ValueTask DeleteAsync(string key)
    {
        appCache.Remove(key);
        
        return ValueTask.CompletedTask;
    }
    
    //public MemoryCacheEntryOptions GetCacheEntryOptions(CacheO)
}