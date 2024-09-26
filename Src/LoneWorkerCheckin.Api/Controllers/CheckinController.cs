using Azure;

namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckinController : ControllerBase
{
    [HttpPost(Name = "PostCheckin")]
    public async Task<ActionResult> PostCheckinAsync (CheckinRequest checkin)
    {
        // persist posted informtion into sql server
        // return a status code
        return CreatedAtRoute("GetCheckinById", new { checkinId = Guid.NewGuid() });
    }

    [HttpGet(Name = "GetCheckinById")]
    public async Task<ActionResult<CheckinResponse>> GetCheckinByIdAsync(Guid checkinId)
    {
        //if (_fakeDatabase.ContainsKey(checkinId) == false)
        {
            return NotFound();
        }

        //var response = _fakeDatabase[email];
        //return Ok(response);

    }

}

public class CheckinResponse 
{
    public Guid CheckinId { get; set; }
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
    public Guid LocationId { get; set; }
    public string GridReference { get; set; }
    public DateTime TimeStamp { get; set; }    
}

public class CheckinRequest
{
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
    public Guid LocationId { get; set; }
    public string GridReference { get; set; }
}

