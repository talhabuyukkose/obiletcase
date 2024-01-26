using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Obilet.Core.Interfaces;

namespace Obilet.Infrastructure.Services.Cookie;

public class CookieService<T>(IHttpContextAccessor httpContextAccessor) : ICookieService<T>
{
    /// <summary>
    /// Added generic value to Cookie
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTimeSpan"></param>
    public void SetCookie(string key, T value, TimeSpan expirationTimeSpan)
    {
        var options = new CookieOptions
        {
            MaxAge = expirationTimeSpan
        };
        var cookieValue = JsonSerializer.Serialize(value);

        httpContextAccessor.HttpContext.Response.Cookies.Append(key, cookieValue, options);
    }

    /// <summary>
    /// Get generic value with key from Cookie
    /// </summary>
    /// <param name="key"></param>
    /// <returns> Return value on generic type</returns>
    public T? GetCookie(string key)
    {
        var value = httpContextAccessor.HttpContext.Request.Cookies[key];
        if (string.IsNullOrEmpty(value))
            return default(T);
        else
            return JsonSerializer.Deserialize<T>(value);
    }

    /// <summary>
    /// Remove Cookie with key
    /// </summary>
    /// <param name="key"></param>
    public void RemoveCookie(string key)
    {
        httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
    }
}