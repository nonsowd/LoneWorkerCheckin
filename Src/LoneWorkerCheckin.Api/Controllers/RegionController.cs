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
        var response = data.Select(dataItem => new RegionResponse() { RegionId = dataItem.RegionId, RegionName = dataItem.RegionName }).ToList();
        return Ok(response);
    }        
}

public class RegionResponse
{
    public Guid RegionId { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

