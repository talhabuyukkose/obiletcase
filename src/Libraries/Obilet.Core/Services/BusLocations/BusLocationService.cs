using Obilet.Core.Constants;
using Obilet.Core.Extensions;
using Obilet.Core.Interfaces;
using Obilet.Core.Models.Commons.Requests;
using Obilet.Core.Models.ObiletApiModel.BusLocationModels;

namespace Obilet.Core.Services.BusLocations;

public class BusLocationService : IBusLocationService
{
    private readonly IRedisService<IReadOnlyList<BusLocation>> _redisService;
    private readonly IObiletService _obiletService;
    private readonly ICookieService<DeviceSession> _cookieService;
    private readonly IClientSessionService _clientSessionService;

    public BusLocationService(
        IRedisService<IReadOnlyList<BusLocation>> redisService,
        IObiletService obiletService,
        ICookieService<DeviceSession> cookieService,
        IClientSessionService clientSessionService)
    {
        _redisService = redisService;
        _obiletService = obiletService;
        _cookieService = cookieService;
        _clientSessionService = clientSessionService;
    }

    /// <summary>
    /// Gets all locations redis or obilet api
    /// </summary>
    /// <returns> Return BusLocations type of IReadOnlyList</returns>
    private async Task<IReadOnlyList<BusLocation>> GetBusLocationAllAsync()
    {
        if (_redisService.IsKeyExist(RedisContant.BusLocationList))
        {
            var buslocations = await _redisService.GetStringAsync(RedisContant.BusLocationList);

            return buslocations;
        }

        var deviceSession = await _clientSessionService.GetDeviceSession();

        var busLocationResponse = await _obiletService.GetBusLocationAllAsync(deviceSession, Language.Get(deviceSession.IpCountry));

        var busLocationList = busLocationResponse.BusLocations.AsReadOnly();

        _redisService.SetAsync(RedisContant.BusLocationList, busLocationList);

        return busLocationList;
    }

    /// <summary>
    /// Return buslocations from RedisService in case of RedisService has buslocations.
    /// </summary>
    /// <returns> Return BusLocationSearches type of IReadOnlyList  </returns>
    public async Task<IReadOnlyList<BusLocationSearch>> GetBusLocationWithTakeAsync(int takeCount = ApiServiceConstant.TakeCount)
    {
        var busLocations = await GetBusLocationAllAsync();

        return busLocations.Take(takeCount).Select(select => new BusLocationSearch()
        {
            Id = select.Id,
            Label = select.Name,
            Value = select.LongName
        }).ToList();
    }

    /// <summary>
    /// This method get 5 buslocationsearches from Obilet with Location value
    /// </summary>
    /// <param name="location"></param>
    /// <returns> Return BusLocationSearches type of IReadOnlyList  </returns>
    public async Task<IReadOnlyList<BusLocationSearch>> GetBusLocationSearchAsync(string location)
    {
        var deviceSession = await _clientSessionService.GetDeviceSession();

        var busLocationResponse = await _obiletService.GetBusLocationSearchAsync(location, deviceSession, Language.Get(deviceSession.IpCountry));

        var busLocationsIsReadOnly = busLocationResponse.BusLocations.AsReadOnly();

        _redisService.SetAsync(RedisContant.BusLocationSearched, busLocationsIsReadOnly);

        return busLocationsIsReadOnly
            .Take(ApiServiceConstant.TakeCount)
            .Select(select => new BusLocationSearch()
            {
                Id = select.Id,
                Label = select.Name,
                Value = select.LongName
            }).ToList();
    }

    /// <summary>
    /// Its prepare BusLocationList and set to Redis Service
    /// </summary>
    /// <returns></returns>
    public async Task UpdateBusLocationOnRedisAsync()
    {
        var deviceSession = await _clientSessionService.GetDeviceSession();

        var busLocationResponse = await _obiletService.GetBusLocationAllAsync(deviceSession, Language.Get(deviceSession.IpCountry));

        await _redisService.SetAsync(RedisContant.BusLocationList, busLocationResponse.BusLocations.AsReadOnly());
    }
}