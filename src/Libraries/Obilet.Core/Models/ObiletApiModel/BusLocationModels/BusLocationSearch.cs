namespace Obilet.Core.Models.ObiletApiModel.BusLocationModels;

/// <summary>
/// This model is using for search on getbuslocations endpoint and is using for locations for example Home index view
/// </summary>
public sealed class BusLocationSearch
{
    /// <summary>
    /// LocationId
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }

    public string Label { get; set; }
}