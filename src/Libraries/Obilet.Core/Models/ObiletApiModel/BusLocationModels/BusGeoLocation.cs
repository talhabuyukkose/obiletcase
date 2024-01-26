using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusLocationModels;

/// <summary>
/// This model gives location in BusLocation model
/// </summary>
public sealed class BusGeoLocation
{
    /// <summary>
    /// The location's latitude.
    /// </summary>
    [JsonPropertyName("latitude")] public double Latitude { get; set; }
    /// <summary>
    /// The location's longitude.
    /// </summary>
    [JsonPropertyName("longitude")] public double Longitude { get; set; }
    /// <summary>
    /// Retuns the google maps default zoom level for displaying geo-coordinates of the location.
    /// </summary>
    [JsonPropertyName("zoom")] public int Zoom { get; set; }
}