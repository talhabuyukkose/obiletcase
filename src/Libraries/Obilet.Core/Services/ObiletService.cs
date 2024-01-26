using Microsoft.Extensions.Options;
using Obilet.Core.Extensions;
using Obilet.Core.Interfaces;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels.Requests;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels.Responses;
using Obilet.Core.Models.ObiletApiModel.BusLocationModels.Requests;
using Obilet.Core.Models.ObiletApiModel.BusLocationModels.Responses;
using Obilet.Core.Models.ObiletApiModel.SessionModels;
using Obilet.Core.Models.ObiletApiModel.SessionModels.Requests;
using Obilet.Core.Models.ObiletApiModel.SessionModels.Responses;
using Obilet.Core.Settings;

namespace Obilet.Core.Services;

public class ObiletService : IObiletService
{
    private readonly IObiletApiClient _obiletApiClient;
    private readonly IOptions<ObiletSetting> _options;

    public ObiletService(IObiletApiClient obiletApiClient, IOptions<ObiletSetting> options)
    {
        _obiletApiClient = obiletApiClient;
        _options = options;
    }

    /// <summary>
    /// Create a session for the user by Obilet Api
    /// </summary>
    /// <returns>Return SessionResponse model</returns>
    public async Task<SessionResponse> GetSessionAsync(SessionConnection sessionConnection, SessionBrowser sessionBrowser)
    {
        var sessionRequest = new SessionRequest
        {
            Type = 1,
            Connection = sessionConnection,
            Browser = sessionBrowser
        };
        return await _obiletApiClient.PostAsync<SessionResponse, SessionRequest>(_options.Value.Client_GetSession, sessionRequest);
    }

    /// <summary>
    /// Get all buslocations from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <returns>Return BusLocationResponse model</returns>
    public async Task<BusLocationResponse> GetBusLocationAllAsync(DeviceSession deviceSession, string language)
    {
        var busLocationRequest = new BusLocationRequest()
        {
            Data = null,
            Date = DateTime.Now,
            DeviceSession = deviceSession,
            Language = Language.Get(deviceSession.IpCountry)
        };
        var busLocationResponse = await _obiletApiClient.PostAsync<BusLocationResponse, BusLocationRequest>(_options.Value.Location_GetBusLocations, busLocationRequest);

        return busLocationResponse;
    }

    /// <summary>
    /// Get all buslocations from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <returns>Return BusLocationResponse</returns>
    public async Task<BusLocationResponse> GetBusLocationSearchAsync(string data, DeviceSession deviceSession, string language)
    {
        var busLocationRequest = new BusLocationRequest()
        {
            Data = data,
            Date = DateTime.Now,
            DeviceSession = deviceSession,
            Language = Language.Get(deviceSession.IpCountry)
        };
        return await _obiletApiClient.PostAsync<BusLocationResponse, BusLocationRequest>(_options.Value.Location_GetBusLocations, busLocationRequest);
    }

    /// <summary>
    /// Get journeys in case of given origin-id, destination-id, and date from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <param name="busJourneySearch"></param>
    /// <returns>Return BusJourneyResponse</returns>
    public async Task<BusJourneyResponse> GetBusJourneysAsync(DeviceSession deviceSession, string language, BusJourneySearch busJourneySearch)
    {
        var busJourneyRequest = new BusJourneyRequest()
        {
            BusJourneySearch = busJourneySearch,
            Date = DateTime.Now,
            DeviceSession = deviceSession,
            Language = Language.Get(deviceSession.IpCountry)
        };
        return await _obiletApiClient.PostAsync<BusJourneyResponse, BusJourneyRequest>(_options.Value.Journey_GetBusJourneys, busJourneyRequest);
    }
}