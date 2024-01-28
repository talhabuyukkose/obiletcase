using Obilet.Core.Constants;
using Obilet.Core.Extensions;
using Obilet.Core.Interfaces;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

namespace Obilet.Core.Services.BusJourneys;

public class BusJourneysService : IBusJourneysService
{
    private readonly IRedisService<IReadOnlyList<BusJourney>> _redisService;
    private readonly IObiletService _obiletService;
    private readonly ICookieService<DeviceSession> _cookieService;
    private readonly IClientSessionService _clientSessionService;

    public BusJourneysService(IRedisService<IReadOnlyList<BusJourney>> redisService, IObiletService obiletService, ICookieService<DeviceSession> cookieService,
        IClientSessionService clientSessionService)
    {
        _redisService = redisService;
        _obiletService = obiletService;
        _cookieService = cookieService;
        _clientSessionService = clientSessionService;
    }

    /// <summary>
    /// This metot get bus journeys from ObiletApi
    /// Set data to Redis
    /// </summary>
    /// <param name="busJourneySearch"></param>
    /// <returns> Return BusJourneys type of IReadOnlyList  </returns>
    public async Task<IReadOnlyList<BusJourney>> GetBusJourneysAsync(BusJourneySearch busJourneySearch)
    {
        var redisKey = $"{RedisContant.BusJourneyList}-{busJourneySearch.OriginId}-{busJourneySearch.DestinationId}-{busJourneySearch.DepartureDate.Day}";

        if (_redisService.IsKeyExist(redisKey))
        {
            return await _redisService.GetStringAsync(redisKey);
        }

        var deviceSession = await _clientSessionService.GetDeviceSession();

        var busJourneyResponse = await _obiletService.GetBusJourneysAsync(deviceSession, Language.Get(deviceSession.IpCountry), busJourneySearch);

        var busJourneysReadOnly = busJourneyResponse.BusJourneys.AsReadOnly();
        
        _redisService.SetAsync(redisKey, busJourneysReadOnly, DateTimeOffset.Now.AddDays(1), TimeSpan.FromHours(1));

        return busJourneysReadOnly.OrderBy(order => order.JourneyDetail.Departure).ToList();
    }
}