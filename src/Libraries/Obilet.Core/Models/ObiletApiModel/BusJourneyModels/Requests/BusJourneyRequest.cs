using System.Text.Json.Serialization;
using Obilet.Core.Models.Commons.Requests.Requests;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels.Requests;

/// <summary>
/// ObiletApi GetJourneys model for Request
/// </summary>
public sealed class BusJourneyRequest : ObiletApiBaseRequest
{
    /// <summary>
    /// Optional query string for filtering bus journeys.
    /// </summary>
    [JsonPropertyName("data")]
    public BusJourneySearch BusJourneySearch { get; set; }
}