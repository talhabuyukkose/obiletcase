namespace Obilet.WebApp.Models;

public sealed class BusJourneySearchModel
{
    /// <summary>
    ///  Id of the origin location.
    /// </summary>
    public int? OriginId { get; set; }

    public string? OriginName { get; set; }

    /// <summary>
    ///  Id of the destination location.
    /// </summary>
    public int? DestinationId { get; set; }

    public string? DestinationName { get; set; }

    /// <summary>
    /// Date for the bus journey (YYYY-MM-DDThh:mm:ss)
    /// </summary>
    public DateTime DepartureDate { get; set; }
}