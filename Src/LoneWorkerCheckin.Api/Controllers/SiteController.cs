namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SiteController : ControllerBase
{

    [HttpGet(Name = "GetSiteInformation")]
    public async Task<ActionResult<List<SiteResponse>>> GetSitesByRegionAsync(Guid regionId)
    {
        // TODO: implement the APi for sites 

        return null!;
    }
}
