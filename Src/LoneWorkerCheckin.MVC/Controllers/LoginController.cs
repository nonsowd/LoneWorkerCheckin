using Microsoft.AspNetCore.Mvc;
using LoneWorkerCheckin.Api.Client;

namespace LoneWorkerCheckin.MVC.Controllers;

public class LoginController : Controller
{
    private readonly ILogger <LoginController> _logger;
    private readonly ILoneWorkerCheckinApiClient _loneWorkerCheckinApiClient;

    public LoginController(ILogger <LoginController> logger, ILoneWorkerCheckinApiClient loneWorkerCheckinApiClient)
    {
        _logger = logger;
        _loneWorkerCheckinApiClient = loneWorkerCheckinApiClient;
    }

    public IActionResult Index()
    {
        return View();
    }
}
