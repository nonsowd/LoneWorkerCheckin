namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    [HttpGet(Name = "GetRegionsList")]
    public async Task<ActionResult<List<RegionResponse>>> GetRegionListAsync()
    {
        return null!;
    }
}
