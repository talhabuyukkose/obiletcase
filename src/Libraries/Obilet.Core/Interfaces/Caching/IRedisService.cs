namespace Obilet.Core.Interfaces;

public interface IRedisService<T>
{
    /// <summary>
    /// Added values are kept in Redis. Waits generic value and string key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task SetAsync(string key, T value);
    
    /// <summary>
    /// Added values are kept in Redis. Waits generic value, string key, absolute expire time and slide expire time.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="absoluteExpiration"></param>
    /// <param name="slidingExpiration"></param>
    /// <returns></returns>
    Task SetAsync(string key, T value, DateTimeOffset absoluteExpiration, TimeSpan slidingExpiration);
    /// <summary>
    /// Gives generic value from redis
    /// </summary>
    /// <param name="key"></param>
    /// <returns> Return value on generic type</returns>
    Task<T> GetStringAsync(string key);
    /// <summary>
    /// Remove value with key from Redis
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task RemoveAsync(string key);
    /// <summary>
    /// Is exist the given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool IsKeyExist(string key);

    
}