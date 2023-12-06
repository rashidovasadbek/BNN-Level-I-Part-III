using Cashing.Infra.Domain.Common.Caching;

namespace Cashing.Infra.Persistence.cashing;

public interface ICacheBroker
{
    ValueTask<T> GetAsync<T>(string key);
    
    ValueTask<bool> TryGetAsync<T>(string key, out T? value);

    ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default);

    ValueTask SetASync<T>(string key, T value, CacheEntryOptions? entryOptions = default);

    ValueTask DeleteAsync(string key);
}