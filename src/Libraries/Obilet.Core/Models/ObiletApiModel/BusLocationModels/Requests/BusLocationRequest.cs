using System.Text.Json.Serialization;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.Commons.Requests.Requests;

namespace Obilet.Core.Models.ObiletApiModel.BusLocationModels.Requests;

/// <summary>
/// ObiletApi GetBusLocations model for Request
/// </summary>
public sealed class BusLocationRequest : ObiletApiBaseRequest
{
    /// <summary>
    /// Optional query string for filtering bus locations. Returns all possible locations if not provided.
    /// </summary>
    [JsonPropertyName("data")] public object Data { get; set; }
}