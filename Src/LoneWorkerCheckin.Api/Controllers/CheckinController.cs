namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckinController : ControllerBase
{
    [HttpPost(Name = "PostCheckin")]
    public async Task<ActionResult> PostCheckinAsync (CheckinRequest checkin)
    {
        return null!;
    }
}
