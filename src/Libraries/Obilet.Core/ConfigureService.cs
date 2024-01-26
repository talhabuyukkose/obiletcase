using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Obilet.Core.Interfaces;
using Obilet.Core.Services;
using Obilet.Core.Services.BusJourneys;
using Obilet.Core.Services.BusLocations;
using Obilet.Core.Services.ClientSessions;
using Obilet.Core.Services.CronJobs;
using Obilet.Core.Settings;

namespace Obilet.Core;

public static class ConfigureService
{
    public static void AddCoreConfigureService(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.Configure<ObiletSetting>(configuration.GetSection(ObiletSetting.SettingKey));

        serviceCollection.AddScoped<IObiletService, ObiletService>();
        serviceCollection.AddScoped<IClientSessionService, ClientSessionService>();
        serviceCollection.AddScoped<IBusLocationService, BusLocationService>();
        serviceCollection.AddScoped<IBusJourneysService, BusJourneysService>();

        serviceCollection.AddHostedService<BusLocationsCron>();
    }
}