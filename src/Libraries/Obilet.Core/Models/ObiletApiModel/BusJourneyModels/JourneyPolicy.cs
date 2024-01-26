using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// This model using  data in JourneyDetail model
/// </summary>
public sealed class JourneyPolicy
{
    /// <summary>
    /// Maximum number of seats that can be booked or purchased in a single transaction.
    /// </summary>
    [JsonPropertyName("max-seats")]
    public string? MaxSeats { get; set; }

    /// <summary>
    /// Maximum number of seats that can be booked or purchased in a single transaction.
    /// </summary>
    [JsonPropertyName("max-single")]
    public int? MaxSingle { get; set; }

    /// <summary>
    /// Maximum number of single seated male passengers allowed in the bus
    /// </summary>
    [JsonPropertyName("max-single-males")]
    public int? MaxSingleMales { get; set; }

    /// <summary>
    /// Maximum number of single seated female passengers allowed in the bus
    /// </summary>
    [JsonPropertyName("max-single-females")]
    public int? MaxSingleFemales { get; set; }

    /// <summary>
    /// A value indicating whether male and female passengers are allowed to seat on adjacent seats.
    /// </summary>
    [JsonPropertyName("mixed-genders")]
    public bool MixedGenders { get; set; }

    /// <summary>
    /// A value indicating whether the national identification numbers of the passengers are required during transaction.
    /// </summary>
    [JsonPropertyName("gov-id")]
    public bool GovId { get; set; }

    /// <summary>
    /// A value indicating whether the bus operates on the left-hand traffic, which means the lane designated for normal driving is on the right.
    /// </summary>
    [JsonPropertyName("lht")]
    public bool Lht { get; set; }
}