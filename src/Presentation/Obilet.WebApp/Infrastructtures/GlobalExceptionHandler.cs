using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Obilet.Core.Interfaces;
using Obilet.Core.Services.BusJourneys;
using Obilet.WebApp.Controllers;
using Obilet.WebApp.Models;

namespace Obilet.WebApp.Infrastructtures;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An unexpected error occurred");

        
        return false;
    }
}