using Cashing.Infra.Domain.Common.Caching;
using Cashing.Infra.Infrastructure.Common.Settings;
using Cashing.Infra.Persistence.cashing;
using Force.DeepCloner;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Cashing.Infra.Infrastructure.Common.Cashing.Brokers;

public class LazyMemoryCacheBroker(IAppCache appCache, IOptions<CacheSettings> cacheSettings) : ICacheBroker
{

    private readonly MemoryCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };

    public async ValueTask<T> GetAsync<T>(string key) => await appCache.GetAsync<T>(key);
    
    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        return new ValueTask<bool>(appCache.TryGetValue(key, out value));
    }

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory,  CacheEntryOptions? entryOptions = default)
    {
        return await appCache.GetOrAddAsync(key, valueFactory, GetCacheEntryOptions(entryOptions));
    }

    public ValueTask SetASync<T>(string key, T value,  CacheEntryOptions? entryOptions = default)
    {
        appCache.Add(key, value, GetCacheEntryOptions(entryOptions));
        
        return ValueTask.CompletedTask;
    }

    public ValueTask DeleteAsync(string key)
    {
        appCache.Remove(key);
        
        return ValueTask.CompletedTask;
    }

    public MemoryCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeNow.HasValue && !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}