using System;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Obilet.Core.Interfaces;

namespace Obilet.Infrastructure.Services.DistrubitedCaching;

public class RedisService<T>(IDistributedCache distributedCache) : IRedisService<T>
{
    // <summary>
    /// Added values are kept in Redis. Waits generic value and string key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async Task SetAsync(string key, T value)
    {
        var stringValue = JsonSerializer.Serialize(value);

        await distributedCache.SetStringAsync(key: key, value: stringValue);
    }

    /// <summary>
    /// Added values are kept in Redis. Waits generic value, string key, absolute expire time and slide expire time.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="absoluteExpiration"></param>
    /// <param name="slidingExpiration"></param>
    /// <returns></returns>
    public async Task SetAsync(string key, T value, DateTimeOffset absoluteExpiration, TimeSpan slidingExpiration)
    {
        var stringValue = JsonSerializer.Serialize(value);

        await distributedCache.SetStringAsync(key: key, value: stringValue, options: new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = absoluteExpiration,
            SlidingExpiration = slidingExpiration
        });
    }

    /// <summary>
    /// Gives generic value from redis
    /// </summary>
    /// <param name="key"></param>
    /// <returns> Return value on generic type</returns>
    public async Task<T> GetStringAsync(string key)
    {
        var cacheValue = await distributedCache.GetStringAsync(key: key) ?? string.Empty;

        return JsonSerializer.Deserialize<T>(cacheValue) ?? default;
    }

    /// <summary>
    /// Remove value with key from Redis
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async Task RemoveAsync(string key)
    {
        await distributedCache.RemoveAsync(key: key);
    }

    /// <summary>
    /// Is exist the given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsKeyExist(string key)
    {
        return distributedCache.Get(key) != null;
    }
}