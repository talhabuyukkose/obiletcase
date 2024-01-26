using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.SessionModels;

public sealed class SessionBrowser
{
    /// <summary>
    /// browser name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Browser version
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }
}