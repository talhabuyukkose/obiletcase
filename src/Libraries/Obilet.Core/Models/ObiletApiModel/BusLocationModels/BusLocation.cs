using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusLocationModels;

/// <summary>
/// This model gives Buslocation in data from GetBusLocations response
/// </summary>
public sealed class BusLocation
{
    /// <summary>
    /// Id of the location.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Id of the hierarchical parent of the location, if any
    /// </summary>
    [JsonPropertyName("parent-id")]
    public int ParentId { get; set; }

    /// <summary>
    /// Type of the location. (All bus locations represented in the system are of Town type)
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Name of the location that will be displayed to users
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// LongName of the location that will be displayed to users
    /// </summary>
    [JsonPropertyName("long-name")]
    public string LongName { get; set; }

    /// <summary>
    /// The geo-coordinates of the location.
    /// </summary>
    [JsonPropertyName("geo-location")]
    public BusGeoLocation GeoLocation { get; set; }

    /// <summary>
    /// Returns the time zone code of the location as specified in Microsoft Time Zone Index Values.
    /// </summary>
    [JsonPropertyName("tz-code")]
    public string TzCode { get; set; }

    /// <summary>
    /// Weather code for the location
    /// </summary>
    [JsonPropertyName("weather-code")]
    public string WeatherCode { get; set; }

    /// <summary>
    /// Display rank of the location, if any.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// Reference code of the location
    /// </summary>
    [JsonPropertyName("reference-code")]
    public string ReferenceCode { get; set; }

    /// <summary>
    ///  Keywords specified for the location
    /// </summary>
    [JsonPropertyName("keywords")]
    public string Keywords { get; set; }
}