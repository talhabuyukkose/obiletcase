using System.Text.Json.Serialization;

namespace Obilet.Core.Models.Commons.Requests.Requests;
/// <summary>
/// This model is Obilet api base request model
/// </summary>
public abstract class ObiletApiBaseRequest
{
    /// <summary>
    /// This property is client session infos
    /// </summary>
    [JsonPropertyName("device-session")] public DeviceSession DeviceSession { get; set; }

    /// <summary>
    /// date info for request
    /// </summary>
    [JsonPropertyName("date")] public DateTime Date { get; set; }
    /// <summary>
    /// The property is language of client
    /// </summary>
    [JsonPropertyName("language")] public string Language { get; set; }
}