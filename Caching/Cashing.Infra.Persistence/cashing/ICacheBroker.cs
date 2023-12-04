namespace Cashing.Infra.Persistence.cashing;

public interface ICacheBroker
{
    ValueTask<T> GetAsync<T>(string key);

    ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory);

    ValueTask SetASync<T>(string key, T value);

    ValueTask DeleteAsync(string key);
}