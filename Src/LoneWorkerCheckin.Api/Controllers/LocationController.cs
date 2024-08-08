using Microsoft.AspNetCore.Authorization;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    [Authorize(Roles = "Admin")] // TODO: implement jwt authentication and role based authorisation
    [HttpGet(Name = "GetLocationInformation")]
    public async Task<ActionResult<List<LocationResponse>>> GetLocationBySiteAsync(Guid siteId)
    {
        return null!;
    }
}
