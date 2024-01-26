using System.Text.Json.Serialization;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.Commons.Responses;

namespace Obilet.Core.Models.ObiletApiModel.SessionModels.Responses;

/// <summary>
/// this model is response of GetSession enpoint in data
/// </summary>
public sealed class SessionResponse : ObiletApiBaseResponse
{
    /// <summary>
    /// SessionConnection property using for client infos
    /// </summary>
    [JsonPropertyName("data")] public DeviceSession DeviceSession { get; set; }
}