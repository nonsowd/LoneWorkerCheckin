using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoneWorkerCheckin.MVC.Models;

namespace LoneWorkerCheckin.MVC.Controllers;

public class HomeController : ControllerBase
{
    public HomeController(ILogger<HomeController> logger)
        : base(logger) { }

    public IActionResult Index()
    {
        _logger.LogInformation("moo");

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
