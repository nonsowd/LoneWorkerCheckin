using Microsoft.AspNetCore.Mvc;
using LoneWorkerCheckin.Api.Client;

namespace LoneWorkerCheckin.MVC.Controllers;

public class LoginController : ControllerBase
{
    private readonly ILoneWorkerCheckinApiClient _loneWorkerCheckinApiClient;

    public LoginController(
        ILogger<LoginController> logger,
        ILoneWorkerCheckinApiClient loneWorkerCheckinApiClient)
        : base(logger) 
    {
        _loneWorkerCheckinApiClient = loneWorkerCheckinApiClient;
    }

    public IActionResult Index()
    {
        return View();
    }
}
