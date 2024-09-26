using LoneWorkerCheckin.Infrastructure.EntityFramework;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SiteController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    public SiteController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetSiteInformation")]
    public async Task<ActionResult<List<SiteResponse>>> GetSitesByRegionAsync(Guid regionId)
    {
        var data = _dbContext.Sites.Where(s => s.RegionId == regionId).ToList();

        var response = data.Select(dataItem => new SiteResponse() { SiteId = dataItem.RegionId, SiteName = dataItem.SiteName }).ToList();

        return Ok(response);

        // TODO: implement the APi for sites 
    }
}

public class SiteResponse
{
    public Guid SiteId { get; set; }
    public string SiteName { get; set; } = string.Empty;
}

