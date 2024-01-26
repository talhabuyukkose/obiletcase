using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.Commons.Responses;

/// <summary>
/// This model is Obilet api base response model
/// </summary>
public abstract class ObiletApiBaseResponse
{
    /// <summary>
    /// Enumeration value representing the status of request made. (see Appendix A at the end of the document).
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Error description for current response, if response status is not success.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// User friendly message that explains current response status, if required.
    /// </summary>
    [JsonPropertyName("user-message")] public string UserMessage { get; set; }

    /// <summary>
    /// Unique identifier which represents current request made.
    /// </summary>
    [JsonPropertyName("api-request-id")] public string ApiRequestId { get; set; }

    /// <summary>
    /// Controller that generated current response
    /// </summary>
    [JsonPropertyName("controller")] public string Controller { get; set; }
}