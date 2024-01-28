using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Obilet.Core.Constants;
using Obilet.Core.Interfaces;
using Obilet.Core.Settings;
using Obilet.Infrastructure.Services.Cookie;
using Obilet.Infrastructure.Services.DistrubitedCaching;
using Obilet.Infrastructure.Services.Obilet;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Obilet.Infrastructure;

public static class ConfigureService
{
    public static void AddInfrastructureConfigureService(this IServiceCollection serviceCollection,
        IConfiguration configuration, IHostEnvironment hostEnvironment, ILoggingBuilder loggingBuilder)
    {
        var obiletSetting = new ObiletSetting();
        configuration.GetSection(ObiletSetting.SettingKey).Bind(obiletSetting);

        serviceCollection.AddScoped<IObiletApiClient, ObiletApiClient>();
        serviceCollection.AddScoped(typeof(IRedisService<>), typeof(RedisService<>));
        serviceCollection.AddScoped(typeof(ICookieService<>), typeof(CookieService<>));
        serviceCollection.AddStackExchangeRedisCache(options => { options.Configuration = configuration["Redis:Configuration"]; });

        //Named Client
        serviceCollection.AddHttpClient(ApiClientConstant.ObiletApiCLientName,
            client =>
            {
                client.BaseAddress = new Uri(obiletSetting.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {obiletSetting.Token}");
            });

        // loggingBuilder.AddOpenTelemetry(options =>
        // {
        //     options
        //         .SetResourceBuilder(
        //             ResourceBuilder.CreateDefault()
        //                 .AddService(hostEnvironment.ApplicationName))
        //         .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); });
        // });
        
        serviceCollection.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(hostEnvironment.ApplicationName))
            .WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); }))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); }));
    }
}