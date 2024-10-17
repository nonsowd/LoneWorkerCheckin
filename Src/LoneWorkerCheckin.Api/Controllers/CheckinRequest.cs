namespace LoneWorkerCheckin.Api.Controllers;

public class CheckinRequest
{
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
    public Guid LocationId { get; set; }
    public string GridReference { get; set; }
}

