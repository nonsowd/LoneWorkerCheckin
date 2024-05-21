namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase    
{
    [HttpGet(Name = "GetUserInformation")]
    public async Task<ActionResult<UserResponse>> GetUserAsync (string email)
    {
        return null!;
    }
}
