using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace Obilet.Infrastructure;

public class LoggingService
{
    
    public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogging => (context, loggerConfiguration) =>
    {
        var environment = context.HostingEnvironment;

        loggerConfiguration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("Env", environment.EnvironmentName)
            .Enrich.WithProperty("AppName", environment.ApplicationName);

        var elasticSearchBaseUrl = context.Configuration.GetSection("ElasticSearch")["BaseUrl"];
        var elasticSearcUserName = context.Configuration.GetSection("ElasticSearch")["UserName"];
        var elasticSearchPassword = context.Configuration.GetSection("ElasticSearch")["Password"];
        var elasticSearchIndexName = context.Configuration.GetSection("ElasticSearch")["IndexName"];

        loggerConfiguration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchBaseUrl)) 
        {
            AutoRegisterTemplate = true,// log kayıtlarını belirli bir indekse yazarken kullanılacak olan index template'ini otomatik olarak kaydetme işlevini kontrol eder.
            AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv8,
            IndexFormat = $"{elasticSearchIndexName}-{environment.EnvironmentName}-logs-{{0:yyy.MM.dd}}", // bucketname  // Her tarih için ayrı index oluşturur.
            ModifyConnectionSettings = x=>x.BasicAuthentication(elasticSearcUserName,elasticSearchPassword),
            CustomFormatter = new ElasticsearchJsonFormatter()
        });
        
        
    };
}