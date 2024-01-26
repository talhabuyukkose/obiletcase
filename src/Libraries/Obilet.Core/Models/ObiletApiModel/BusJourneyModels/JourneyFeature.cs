using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// This model using  data in BusJourney model
/// </summary>
public sealed class JourneyFeature
{
    /// <summary>
    ///  Id of bus feature.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Display priority of bus feature.
    /// </summary>
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    /// <summary>
    ///  Name of bus feature
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of bus feature.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// A value indicating whether the bus feature is promoted.
    /// </summary>
    [JsonPropertyName("is-promoted")]
    public bool IsPromoted { get; set; }

    /// <summary>
    /// Background color of a promoted bus feature in HEXA, RGBA or HSLA format.
    /// </summary>
    [JsonPropertyName("back-color")]
    public string BackColor { get; set; }

    /// <summary>
    /// Background color of a prooted bus feature in HEXA, RGBA or HSLA format
    /// </summary>
    [JsonPropertyName("fore-color")]
    public string ForeColor { get; set; }
}