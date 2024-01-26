using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.SessionModels;

/// <summary>
/// SessionConnection model using for client infos
/// </summary>
public sealed class SessionConnection
{
    /// <summary>
    /// Your server's outbound Ip address.
    /// </summary>
    [JsonPropertyName("ip-address")]
    public string IpAddress { get; set; }
    /// <summary>
    /// Your server's outbound port.
    /// </summary>
    [JsonPropertyName("port")]
    public string Port { get; set; }
}