namespace LoneWorkerCheckin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase    
{
    
    private static readonly Dictionary<string, UserResponse> _fakeDatabase = new(StringComparer.CurrentCultureIgnoreCase)
    {
        { "test1@test.com", new UserResponse() { UserId = Guid.NewGuid() } },
        { "test2@test.com", new UserResponse() { UserId = Guid.NewGuid() } }
    };

    [HttpGet(Name = "GetUserInformation")]
    public async Task<ActionResult<UserResponse>> GetUserAsync(string email)
    {
        if (_fakeDatabase.ContainsKey(email) == false)
        {
            return NotFound();
        }

        var response = _fakeDatabase[email];
        return Ok(response);

    }
}

public class UserResponse
{
    public Guid UserId { get; set; }
}
