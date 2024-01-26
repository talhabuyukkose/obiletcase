using Obilet.Core.Models.ObiletApiModel.BusJourneyModels;

namespace Obilet.Core.Interfaces;

public interface IBusJourneysService
{
    /// <summary>
    /// This metot get bus journeys from ObiletApi
    /// </summary>
    /// <param name="busJourneySearch"></param>
    /// <returns> Return BusJourneys type of IReadOnlyList  </returns>
    Task<IReadOnlyList<BusJourney>> GetBusJourneysAsync(BusJourneySearch busJourneySearch);
}