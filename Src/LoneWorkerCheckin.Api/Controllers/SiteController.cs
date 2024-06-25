namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SiteController : ControllerBase
{

    [HttpGet(Name = "GetSiteInformation")]
    public async Task<ActionResult<List<SiteResponse>>> GetSitesByRegionAsync(Guid region)
    {
        return null!;
    }
}
