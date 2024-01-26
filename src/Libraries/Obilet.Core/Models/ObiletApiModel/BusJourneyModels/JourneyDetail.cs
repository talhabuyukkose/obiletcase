using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// This model using  data in BusJourney model
/// </summary>
public sealed class JourneyDetail
{
    /// <summary>
    /// Kind of the journey (bus)
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    /// <summary>
    /// code that uniquely identifies the journey to its provider
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// Array of all the bus stops that the journey travels.
    /// </summary>
    [JsonPropertyName("stops")]
    public IList<JourneyStop> Stops { get; set; }

    /// <summary>
    /// Name of the origin stop of the journey.
    /// </summary>
    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    /// <summary>
    /// Name of the destination stop of the journey
    /// </summary>
    [JsonPropertyName("destination")]
    public string Destination { get; set; }

    /// <summary>
    /// Departure time of the journey
    /// </summary>
    [JsonPropertyName("departure")]
    public DateTime Departure { get; set; }

    /// <summary>
    ///  Arrival time of the journey.
    /// </summary>
    [JsonPropertyName("arrival")]
    public DateTime Arrival { get; set; }

    /// <summary>
    /// ISO 4217 code of the accepted currency for buying tickets of the journey.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Duration of the journey (Hour HH:MM:SS).
    /// </summary>
    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    /// <summary>
    /// Original listing price of the journey.
    /// </summary>
    [JsonPropertyName("original-price")]
    public double OriginalPrice { get; set; }

    /// <summary>
    ///  Internet listing price of the journey.
    /// </summary>
    [JsonPropertyName("internet-price")]
    public double InternetPrice { get; set; }

    [JsonPropertyName("provider-internet-price")]
    public double? ProviderInternetPrice { get; set; }

    /// <summary>
    /// Booking rules specified for the journey.
    /// </summary>
    [JsonPropertyName("booking")]
    public string Booking { get; set; }

    /// <summary>
    /// Brand and model of the physical bus, if specified.
    /// </summary>
    [JsonPropertyName("bus-name")]
    public string BusName { get; set; }

    /// <summary>
    /// Layout policy providing the seating rules.
    /// </summary>
    [JsonPropertyName("policy")]
    public JourneyPolicy Policy { get; set; }

    [JsonPropertyName("features")] public IList<string> Features { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("available")] public string Available { get; set; }
}