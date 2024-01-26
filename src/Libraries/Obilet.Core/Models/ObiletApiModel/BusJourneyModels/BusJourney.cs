using System.Text.Json.Serialization;

namespace Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

/// <summary>
/// ObiletApi  BusJourney model from GetJourneys Request
/// </summary>
public sealed class BusJourney
{
    /// <summary>
    /// Id of the journey. Used for redirecting users to obilet.com bus journey details page to display specific journey detail
    /// information page through the url pattern provided later in the document.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Id of the bus firm commissioning this journey.
    /// </summary>
    [JsonPropertyName("partner-id")]
    public int PartnerId { get; set; }

    /// <summary>
    /// Name of the bus firm commissioning this journey
    /// </summary>
    [JsonPropertyName("partner-name")]
    public string PartnerName { get; set; }

    /// <summary>
    /// Id of the corresponding route.
    /// </summary>
    [JsonPropertyName("route-id")]
    public int RouteId { get; set; }

    /// <summary>
    /// Seat layout type of the bus. (eg: 2+1,2+2)
    /// </summary>
    [JsonPropertyName("bus-type")]
    public string BusType { get; set; }

    [JsonPropertyName("bus-type-name")] public string BusTypeName { get; set; }

    /// <summary>
    /// Total number of seats in the journey.
    /// </summary>
    [JsonPropertyName("total-seats")]
    public int TotalSeats { get; set; }

    /// <summary>
    /// Number of available seats in the journey
    /// </summary>
    [JsonPropertyName("available-seats")]
    public int AvailableSeats { get; set; }

    [JsonPropertyName("journey")] public JourneyDetail JourneyDetail { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("features")]
    public IList<JourneyFeature> Features { get; set; }

    /// <summary>
    /// Name of the origin location
    /// </summary>
    [JsonPropertyName("origin-location")]
    public string OriginLocation { get; set; }

    /// <summary>
    ///  Name of the destination location
    /// </summary>
    [JsonPropertyName("destination-location")]
    public string DestinationLocation { get; set; }

    /// <summary>
    /// A value indicating whether the journey is active
    /// </summary>
    [JsonPropertyName("is-active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Id of the origin location
    /// </summary>
    [JsonPropertyName("origin-location-id")]
    public int OriginLocationId { get; set; }

    /// <summary>
    /// Id of the destination location.
    /// </summary>
    [JsonPropertyName("destination-location-id")]
    public int DestinationLocationId { get; set; }

    /// <summary>
    /// A value indicating whether the bus firm commissioning the journey is promoted by oBilet.
    /// </summary>
    [JsonPropertyName("is-promoted")]
    public bool IsPromoted { get; set; }

    /// <summary>
    /// Time, in hours, before the journey's departure time tickets purchased can be cancelled.
    /// </summary>
    [JsonPropertyName("cancellation-offset")]
    public int? CancellationOffset { get; set; }

    /// <summary>
    /// A value indicating whether the current partner has shuttle for given location.
    /// </summary>
    [JsonPropertyName("has-bus-shuttle")]
    public bool HasBusShuttle { get; set; }

    /// <summary>
    /// A value indicating whether bus firm prevents sale transactions for passengers without a valid gov id.
    /// </summary>
    [JsonPropertyName("disable-sales-without-gov-id")]
    public bool DisableSalesWithoutGovId { get; set; }

    /// <summary>
    /// Timespan which represents the latest time journey is eligible to be displayed in the result list before the journey's departure time.
    /// </summary>
    [JsonPropertyName("display-offset")]
    public TimeSpan DisplayOffset { get; set; }

    /// <summary>
    /// Rating average for this bus firm in last thirty days.
    /// </summary>
    [JsonPropertyName("partner-rating")]
    public double? PartnerRating { get; set; }

    [JsonPropertyName("has-dynamic-pricing")]
    public bool HasDynamicPricing { get; set; }

    [JsonPropertyName("disable-sales-without-hes-code")]
    public bool DisableSalesWithoutHesCode { get; set; }

    [JsonPropertyName("disable-single-seat-selection")]
    public bool DisableSingleSeatSelection { get; set; }

    [JsonPropertyName("change-offset")] public int ChangeOffset { get; set; }

    [JsonPropertyName("rank")] public int Rank { get; set; }

    [JsonPropertyName("display-coupon-code-input")]
    public bool DisplayCouponCodeInput { get; set; }

    [JsonPropertyName("disable-sales-without-date-of-birth")]
    public bool DisableSalesWithoutDateOfBirth { get; set; }

    [JsonPropertyName("open-offset")] public int? OpenOffset { get; set; }

    [JsonPropertyName("display-buffer")] public string DisplayBuffer { get; set; }
}