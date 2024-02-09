using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Obilet.Core.Constants;
using Obilet.Core.Extensions;
using Obilet.Core.Interfaces;
using Obilet.Core.Settings;
using Obilet.Infrastructure.Services.Cookie;
using Obilet.Infrastructure.Services.DistrubitedCaching;
using Obilet.Infrastructure.Services.Obilet;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using StackExchange.Redis;

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

        serviceCollection.AddSingleton<IConnectionMultiplexer>(provider => { return ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]); });
        serviceCollection.AddStackExchangeRedisCache(options => { options.Configuration = configuration["Redis:Configuration"]; });

        //Named Client
        serviceCollection.AddHttpClient(ApiClientConstant.ObiletApiCLientName,
            client =>
            {
                client.BaseAddress = new Uri(obiletSetting.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {obiletSetting.Token}");
            });


        serviceCollection.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(hostEnvironment.ApplicationName))
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation(aspnetoption =>
                {
                    aspnetoption.RecordException = true; // Hataları span/activity olarak kaydet.
                });
                tracing.AddHttpClientInstrumentation(options =>
                {
                    options.RecordException = true;
                    options.EnrichWithException = (activity, exception) =>
                    {
                        activity.AddTag("exception.message", exception.Message);
                    };
                    options.EnrichWithHttpRequestMessage = async (activity, message) =>
                    {
                        activity.AddTag("http.request.body", await message.Content.ReadAsStringAsync());
                    };
                });
                tracing.AddRedisInstrumentation(options => { options.SetVerboseDatabaseStatements = true; });
                tracing.AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); });
            });

        ActivitySourceProvider.Source = new ActivitySource(hostEnvironment.ApplicationName);
        // .WithMetrics(metrics => metrics
        //     .AddAspNetCoreInstrumentation()
        //     .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); }))

        // loggingBuilder.AddOpenTelemetry(options =>
        // {
        //     options
        //         .SetResourceBuilder(
        //             ResourceBuilder.CreateDefault()
        //                 .AddService(hostEnvironment.ApplicationName))
        //         .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); });
        // });
    }
}