namespace Obilet.Core.Interfaces;

public interface ICookieService<T>
{
    /// <summary>
    /// Added generic value to Cookie
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTimeSpan"></param>
    void SetCookie(string key, T value, TimeSpan expirationTimeSpan);
    /// <summary>
    /// Get generic value with key from Cookie
    /// </summary>
    /// <param name="key"></param>
    /// <returns> Return value on generic type</returns>
    T? GetCookie(string key);
    /// <summary>
    /// Remove Cookie with key
    /// </summary>
    /// <param name="key"></param>
    void RemoveCookie(string key);
}