using System.Text.Json.Serialization;
using Obilet.Core.Models.ObiletApiModel.Commons.Responses;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels.Responses;

/// <summary>
/// ObiletApi GetJourneys model for Response
/// </summary>
public sealed class BusJourneyResponse : ObiletApiBaseResponse
{
    /// <summary>
    /// ObiletApi GetJourneys model for Response in data
    /// </summary>
    [JsonPropertyName("data")]
    public IList<BusJourney> BusJourneys { get; set; }
}