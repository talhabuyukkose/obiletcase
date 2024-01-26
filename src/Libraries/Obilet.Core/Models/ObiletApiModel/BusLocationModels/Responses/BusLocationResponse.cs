using System.Text.Json.Serialization;
using Obilet.Core.Models.ObiletApiModel.Commons.Responses;

namespace Obilet.Core.Models.ObiletApiModel.BusLocationModels.Responses;

/// <summary>
/// ObiletApi GetBusLocations model for Response
/// </summary>
public sealed class BusLocationResponse : ObiletApiBaseResponse
{
    /// <summary>
    /// ObiletApi GetBusLocations model for Response in data
    /// </summary>
    [JsonPropertyName("data")] public IList<BusLocation> BusLocations { get; set; }
}