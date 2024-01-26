using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.SessionModels.Requests;

/// <summary>
/// this model is using getsession request
/// </summary>
public sealed class SessionRequest
{
    /// <summary>
    /// Device type specific for distribusion api client
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("connection")]
    public SessionConnection Connection { get; set; }

    [JsonPropertyName("browser")] public SessionBrowser Browser { get; set; }
}