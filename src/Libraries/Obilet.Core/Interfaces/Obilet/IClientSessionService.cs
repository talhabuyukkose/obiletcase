using Obilet.Core.Models.Commons.Requests;

namespace Obilet.Core.Interfaces;

public interface IClientSessionService
{
    /// <summary>
    ///  Gives DeviceSession model from Api or Cookie
    /// </summary>
    /// <returns>Return DeviceSession</returns>
    Task<DeviceSession> GetDeviceSession();
}