using Microsoft.AspNetCore.Http;
using Obilet.Core.Constants;
using Obilet.Core.Interfaces;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.SessionModels;
using UAParser;

namespace Obilet.Core.Services.ClientSessions;

public class ClientSessionService : IClientSessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IObiletService _obiletService;
    private readonly ICookieService<DeviceSession> _cookieService;

    public ClientSessionService(
        IHttpContextAccessor httpContextAccessor,
        IObiletService obiletService,
        ICookieService<DeviceSession> cookieService)
    {
        _httpContextAccessor = httpContextAccessor;
        _obiletService = obiletService;
        _cookieService = cookieService;
    }

    /// <summary>
    ///  Gives DeviceSession model from Api or Cookie
    /// </summary>
    /// <returns>Return DeviceSession</returns>
    public async Task<DeviceSession> GetDeviceSession()
    {
        var deviceSession = _cookieService.GetCookie(CookieConstant.DeviceSesssionCookie);
        if (deviceSession != null)
        {
            return deviceSession;
        }

        var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
        ClientInfo BrowserValue = Parser.GetDefault().Parse(userAgent);

        var sessionBrowser = new SessionBrowser()
        {
            Name = BrowserValue.UA.Family,
            Version = $"{BrowserValue.UserAgent.Major}.{BrowserValue.UserAgent.Minor}.{BrowserValue.UserAgent.Patch}"
        };
        var sessionConnection = new SessionConnection()
        {
            IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
            Port = _httpContextAccessor.HttpContext.Connection.RemotePort.ToString()
        };

        var sessionResponse = await _obiletService.GetSessionAsync(sessionConnection, sessionBrowser);

        _cookieService.SetCookie(CookieConstant.DeviceSesssionCookie, sessionResponse.DeviceSession,
            TimeSpan.FromDays(CookieConstant.DeviceSesssionCookieDay));

        return sessionResponse.DeviceSession;
    }
}