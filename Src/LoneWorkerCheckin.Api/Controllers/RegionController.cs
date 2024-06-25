using LoneWorkerCheckin.Infrastructure.EntityFramework;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private static readonly List<RegionResponse> _regions = new List<RegionResponse>()
    {
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "South East"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "South West"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "Southern"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "Northern"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "Scotland"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "Wales"},
    new RegionResponse() {RegionId = Guid.NewGuid(), RegionName = "Middle England"}
     };

    private readonly ApplicationDbContext _dbContext;

    public RegionController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    [HttpGet(Name = "GetRegionsList")]
    public async Task<ActionResult<List<RegionResponse>>> GetRegionListAsync()
    {
        var data = _dbContext.Regions.ToList();
        var response = _regions;
        return Ok(response);
    }
}
