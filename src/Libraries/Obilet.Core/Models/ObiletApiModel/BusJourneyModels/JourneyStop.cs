using System;
using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// This model using  data in BusJourney model
/// </summary>
public sealed class JourneyStop
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("station")] public string Station { get; set; }

    [JsonPropertyName("time")] public DateTime? Time { get; set; }

    [JsonPropertyName("is-origin")] public bool IsOrigin { get; set; }

    [JsonPropertyName("is-destination")] public bool IsDestination { get; set; }
}