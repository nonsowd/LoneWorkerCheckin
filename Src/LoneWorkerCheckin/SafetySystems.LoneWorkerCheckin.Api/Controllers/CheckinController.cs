using System.ComponentModel.DataAnnotations;
using LoneWorkerCheckin.Infrastructure.EntityFramework;
using LoneWorkerCheckin.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CheckinController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CheckinController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost(Name = "PostCheckin")]
    public async Task<ActionResult> PostCheckinAsync(CheckinRequest checkin, CancellationToken cancellationToken)
    {
        //TODO: Add validation

        var checkinEntity = new CheckinEntity()
        {
            SiteId = checkin.SiteId,
            UserId = checkin.UserId,
            LocationId = checkin.LocationId,
            TimeStamp = DateTime.UtcNow,
        };
        await _dbContext.Checkins.AddAsync(checkinEntity, cancellationToken);
        await _dbContext.SaveChangesAsync();

        return CreatedAtRoute("GetCheckinById", new { checkinId = checkinEntity.CheckinId });
    }

    [HttpGet(Name = "GetCheckinById")]
    public async Task<ActionResult<CheckinResponse>> GetCheckinByIdAsync([Required] Guid checkinId)
    {
        var data = await _dbContext.Checkins.SingleOrDefaultAsync(s => s.CheckinId == checkinId);
        if (data == null)
        {
            return NotFound();
        }

        var response = new CheckinResponse()
        {
            CheckinId = data.CheckinId,
            SiteId = data.SiteId,
            UserId = data.UserId,
            LocationId = data.LocationId,
            TimeStamp = DateTime.UtcNow,
        };
        return Ok(response);
    }
}
