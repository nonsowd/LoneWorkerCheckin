using Microsoft.AspNetCore.Mvc;
using LoneWorkerCheckin.Api.Client;
using System.ComponentModel.DataAnnotations;
using LoneWorkerCheckin.MVC.Models;

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

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        //if (ModelState.IsValid) { }
        var result = await _loneWorkerCheckinApiClient.GetUser(model.Email);
        //if (result == null) {
        model.UserId = result.UserId.ToString();

        return View("Index", model);
    }
}
