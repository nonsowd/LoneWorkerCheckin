using Microsoft.AspNetCore.Mvc;

namespace LoneWorkerCheckin.MVC.Controllers;

public class ControllerBase : Controller
{
    protected readonly ILogger _logger;

    public ControllerBase(ILogger logger)
    {
        _logger = logger;
    }
}
