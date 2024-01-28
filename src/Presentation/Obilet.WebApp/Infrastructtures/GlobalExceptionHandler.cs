using Microsoft.AspNetCore.Diagnostics;

namespace Obilet.WebApp.Infrastructtures;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An unexpected error occurred");

        // All exceptions handle in here
        // If we turn true. It means exception was handled 
        // If we turn false. It means exception was not handled
        return false;
    }
}