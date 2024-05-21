namespace LoneWorkerCheckin.Api.Controllers;

public class CheckinRequest
{
    public Guid UserId { get; set; }
    public Guid AreaId { get; set; }
    public string GridReference { get; set; }
}
