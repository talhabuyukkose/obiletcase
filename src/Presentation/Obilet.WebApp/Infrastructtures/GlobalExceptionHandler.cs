using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Obilet.Core.Extensions;

namespace Obilet.WebApp.Infrastructtures;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        using var activity = ActivitySourceProvider.Source.StartActivity();

        logger.LogError(exception, "An unexpected error occurred");

        if (exception is ArgumentNullException)
        {
            var problemDetails = new ProblemDetails()
            {
                Detail = "detail",
                Extensions = new Dictionary<string, object?>()
                {
                    { "traceId", Activity.Current?.TraceId },
                    { "route", httpContext.Request.Path }
                },
                Instance = "",
                Title = "ArgumentNullException",
                Type = nameof(ArgumentNullException)
            };
            
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
            
            return true;
        }
        // All exceptions handle in here
        // If we turn true. It means exception was handled 
        // If we turn false. It means exception was not handled
        return false;
    }
    
 
}