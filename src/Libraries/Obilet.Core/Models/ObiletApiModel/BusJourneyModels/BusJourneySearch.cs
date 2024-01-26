using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// ObiletApi GetJourneys endpoint in data for request
/// </summary>
public sealed class BusJourneySearch
{
    /// <summary>
    ///  Id of the origin location.
    /// </summary>
    [JsonPropertyName("origin-id")]
    public int OriginId { get; set; }

    /// <summary>
    ///  Id of the destination location.
    /// </summary>
    [JsonPropertyName("destination-id")]
    public int DestinationId { get; set; }

    /// <summary>
    /// Date for the bus journey (YYYY-MM-DDThh:mm:ss)
    /// </summary>
    [JsonPropertyName("departure-date")]
    public DateTime DepartureDate { get; set; }
}