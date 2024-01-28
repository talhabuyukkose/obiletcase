using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels.Responses;
using Obilet.Core.Models.ObiletApiModel.BusLocationModels.Responses;
using Obilet.Core.Models.ObiletApiModel.SessionModels;
using Obilet.Core.Models.ObiletApiModel.SessionModels.Responses;

namespace Obilet.Core.Interfaces;

public interface IObiletService
{
    /// <summary>
    /// Create a session for the user by Obilet Api
    /// </summary>
    /// <returns>Return SessionResponse model</returns>
    Task<SessionResponse> GetSessionAsync(SessionConnection sessionConnection, SessionBrowser sessionBrowser);

    /// <summary>
    /// Get all buslocations from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <returns>Return BusLocationResponse model</returns>
    Task<BusLocationResponse> GetBusLocationAllAsync(DeviceSession deviceSession, string language);

    /// <summary>
    /// Get all buslocations from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <returns>Return BusLocationResponse</returns>
    Task<BusLocationResponse> GetBusLocationSearchAsync(string data, DeviceSession deviceSession, string language);

    /// <summary>
    /// Get journeys in case of given origin-id, destination-id, and date from Api
    /// </summary>
    /// <param name="deviceSession"></param>
    /// <param name="language"></param>
    /// <param name="busJourneySearch"></param>
    /// <returns>Return BusJourneyResponse</returns>
    Task<BusJourneyResponse> GetBusJourneysAsync(DeviceSession deviceSession, string language,
        BusJourneySearch busJourneySearch);
}