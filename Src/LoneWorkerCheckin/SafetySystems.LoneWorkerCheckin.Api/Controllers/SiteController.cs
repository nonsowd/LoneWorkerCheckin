using System.ComponentModel.DataAnnotations;
using SafetySystems.LoneWorkerCheckin.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class SiteController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    public SiteController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetSiteInformation")]
    public async Task<ActionResult<List<SiteResponse>>> GetSitesByRegionAsync([Required] Guid regionId)
    {
        var data = await _dbContext.Sites.Where(s => s.RegionId == regionId).ToListAsync();

        if (data.Count == 0)
           return NotFound();
       
        var response = data.Select(dataItem => new SiteResponse() { SiteId = dataItem.RegionId, SiteName = dataItem.SiteName }).ToList();
        return Ok(response);
    }
}
