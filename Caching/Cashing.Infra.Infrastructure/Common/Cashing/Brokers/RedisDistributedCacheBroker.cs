﻿using System.Net.Http.Json;
using System.Text;
using Cashing.Infra.Domain.Common.Caching;
using Cashing.Infra.Infrastructure.Common.Settings;
using Cashing.Infra.Persistence.cashing;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Cashing.Infra.Infrastructure.Common.Cashing.Brokers;

public class RedisDistributedCacheBroker(IOptions<CacheSettings> cacheSettings, IDistributedCache distributedCache) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };
    
    public async ValueTask<T> GetAsync<T>(string key)
    {
        var value = await distributedCache.GetAsync(key);
        return value is not null ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value)) : default;
    }
    

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        var foundEntry = distributedCache.GetString(key);

        if (foundEntry is not null)
        {
            value = JsonConvert.DeserializeObject<T>(foundEntry);
            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }
    
    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);
        if (cachedValue is not null) return JsonConvert.DeserializeObject<T>(cachedValue);

        var value = await valueFactory();
        await SetASync(key, await valueFactory(), entryOptions);

        return value;
    }

    public async ValueTask SetASync<T>(string key, T value, CacheEntryOptions? entryOptions = default)
    {
        await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value),
            GetCacheEntryOptions(entryOptions));
    }

    public ValueTask DeleteAsync(string key)
    {
        distributedCache.Remove(key);
        
        return ValueTask.CompletedTask;
    }

    public DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeNow.HasValue && !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}