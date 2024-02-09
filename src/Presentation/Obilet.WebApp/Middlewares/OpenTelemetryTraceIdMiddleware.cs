using System.Diagnostics;
using Obilet.Infrastructure;

namespace Obilet.WebApp.Middlewares;

public class OpenTelemetryTraceIdMiddleware 
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<OpenTelemetryTraceIdMiddleware> _logger;

    public OpenTelemetryTraceIdMiddleware(RequestDelegate requestDelegate,ILogger<OpenTelemetryTraceIdMiddleware> logger)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        using (_logger.BeginScope("{@traceId}", Activity.Current?.TraceId.ToString()))
        {
            await _requestDelegate(httpContext);
        }
    } 
    
}