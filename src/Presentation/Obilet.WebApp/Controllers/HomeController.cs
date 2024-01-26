using System.Collections.Specialized;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Obilet.Core.Constants;
using Obilet.Core.Interfaces;
using Obilet.Core.Models.ObiletApiModel.BusJourneyModels;
using Obilet.WebApp.Models;
using StackExchange.Redis;

namespace Obilet.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBusLocationService _busLocationService;
    private readonly IBusJourneysService _busJourneysService;
    private readonly ICookieService<BusJourneySearchModel> _cookieServiceBusJourney;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(ILogger<HomeController> logger,
        IBusLocationService busLocationService,
        IBusJourneysService busJourneysService,
        ICookieService<BusJourneySearchModel> cookieServiceBusJourney)
    {
        _logger = logger;
        _busLocationService = busLocationService;
        _busJourneysService = busJourneysService;
        _cookieServiceBusJourney = cookieServiceBusJourney;
    }


    public async Task<IActionResult> Index()
    {
        ViewBag.ExceptionMessage = TempData["ExceptionMessage"];
        var busJourneySearchModel = _cookieServiceBusJourney.GetCookie(CookieConstant.BusJourneySearchCookie);

        if (busJourneySearchModel is null)
            busJourneySearchModel = new BusJourneySearchModel();
        busJourneySearchModel.DepartureDate = busJourneySearchModel.DepartureDate <= DateTime.Today ? DateTime.Today.AddDays(1) : busJourneySearchModel.DepartureDate;

        ViewBag.busJourneySearchCookie = busJourneySearchModel;

        return View(await _busLocationService.GetBusLocationWithTakeAsync(ApiServiceConstant.TakeCount));
    }

    [HttpPost]
    public async Task<IActionResult> SearchLocations(string searchvalue)
    {
        if (string.IsNullOrEmpty(searchvalue))
            return Json(await _busLocationService.GetBusLocationWithTakeAsync(ApiServiceConstant.TakeCount));

        return Json(await _busLocationService.GetBusLocationSearchAsync(searchvalue));
    }


    [HttpPost]
    public async Task<IActionResult> Journeys(IFormCollection formCollection)
    {
        var originName = formCollection["originName"];
        int.TryParse(formCollection["originId"], out int originId);
        var destinationName = formCollection["destinationName"];
        int.TryParse(formCollection["destinationId"], out int destinationId);
        var departureDate = DateTime.Parse(formCollection["departureDate"]);
        
        if (originName == destinationName)
            return RedirectToAction("Index", "Home");

        BusJourneySearchModel busJourneySearchForCookie = new()
        {
            OriginId = originId,
            OriginName = originName,
            DestinationId = destinationId,
            DestinationName = destinationName,
            DepartureDate = departureDate
        };

        _cookieServiceBusJourney.SetCookie(CookieConstant.BusJourneySearchCookie, busJourneySearchForCookie, TimeSpan.FromDays(CookieConstant.BusJourneySearchCookieDay));

        BusJourneySearch busJourneySearch = new()
        {
            OriginId = originId,
            DestinationId = destinationId,
            DepartureDate = departureDate,
        };

        var busJourneyList = await _busJourneysService.GetBusJourneysAsync(busJourneySearch);

        return View(busJourneyList);
    }

  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var exceptipnFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptipnFeature.Error is HttpRequestException)
        {
            TempData["ExceptionMessage"] = "Teknik bir arıza oluştu lütfen sonra tekrar deneyiniz.";
            return RedirectToAction("Index");
        }

        if (exceptipnFeature is RedisException)
        { 
            TempData["ExceptionMessage"] = "Teknik bir arıza oluştu lütfen sonra tekrar deneyiniz.";
            return RedirectToAction("Index");
        }

        if (exceptipnFeature is TimeoutException)
        {
            TempData["ExceptionMessage"] = "Teknik bir arıza oluştu lütfen sonra tekrar deneyiniz.";
            return RedirectToAction("Index");

        }
        
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}