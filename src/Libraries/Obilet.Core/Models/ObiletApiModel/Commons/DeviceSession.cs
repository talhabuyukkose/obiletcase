using System.Text.Json.Serialization;

namespace Obilet.Core.Models.Commons.Requests;

/// <summary>
/// DeviceSession model is  client session infos
/// </summary>
public sealed class DeviceSession
{
    /// <summary>
    ///  A token which represents current session
    /// </summary>
    [JsonPropertyName("session-id")]
    public string SessionId { get; set; }
    
    /// <summary>
    /// A token which represents current device
    /// </summary>
    [JsonPropertyName("device-id")]
    public string DeviceId { get; set; }
    /// <summary>
    /// A token which represents current device
    /// </summary>
    [JsonIgnore]
    public string IpCountry { get; set; }
}