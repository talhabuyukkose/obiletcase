namespace Obilet.Core.Settings;

public class ObiletSetting
{
    public const string SettingKey = "ObiletSetting";
    /// <summary>
    /// Rest Api base url
    /// </summary>
    public string BaseUrl { get; set; }
    /// <summary>
    /// Rest Api basic access token
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// GetSession method url
    /// </summary>
    public string Client_GetSession { get; set; }
    /// <summary>
    /// BusLocations method url
    /// </summary>
    public string Location_GetBusLocations { get; set; }
    /// <summary>
    /// Journeys method url
    /// </summary>
    public string Journey_GetBusJourneys { get; set; }
}