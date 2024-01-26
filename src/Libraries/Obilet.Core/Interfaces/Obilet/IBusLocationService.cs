using Obilet.Core.Models.ObiletApiModel.BusLocationModels;

namespace Obilet.Core.Interfaces;

public interface IBusLocationService
{
    /// <summary>
    /// Return buslocations from RedisService in case of RedisService has buslocations.
    /// </summary>
    /// <returns> Return BusLocationSearches type of IReadOnlyList  </returns>
    Task<IReadOnlyList<BusLocationSearch>> GetBusLocationWithTakeAsync(int takeCount);

    /// <summary>
    /// This method get 5 buslocationsearches from Obilet with Location value
    /// </summary>
    /// <param name="location"></param>
    /// <returns> Return BusLocationSearches type of IReadOnlyList  </returns>
    Task<IReadOnlyList<BusLocationSearch>> GetBusLocationSearchAsync(string location);
    
    /// <summary>
    /// Its prepare BusLocationList and set to Redis Service
    /// </summary>
    /// <returns></returns>
    Task UpdateBusLocationOnRedisAsync();
}