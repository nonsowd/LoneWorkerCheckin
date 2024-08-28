using LoneWorkerCheckin.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public LocationController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [Authorize(Roles = "Admin")] // TODO: implement jwt authentication and role based authorisation
    [HttpGet(Name = "GetLocationInformation")]
    public async Task<ActionResult<List<LocationResponse>>> GetLocationListyAsync()
    {
        var data = _dbContext.Locations.ToList();
        var response = data.Select(dataItem => new LocationResponse() { LocationId = dataItem.LocationId, LocationName = dataItem.LocationName }).ToList();
        return Ok(response);
    }
}
