using LoneWorkerCheckin.Infrastructure.EntityFramework;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public RegionController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetRegionsList")]
    public async Task<ActionResult<List<RegionResponse>>> GetRegionListAsync()
    {
        var data = _dbContext.Regions.ToList();
        var response = data.Select(a => new RegionResponse() { RegionId = a.RegionId, RegionName = a.RegionName }).ToList();
        return Ok(response);
    }        
}                               
