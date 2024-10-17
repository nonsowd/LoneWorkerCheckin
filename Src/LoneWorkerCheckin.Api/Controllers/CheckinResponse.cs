namespace LoneWorkerCheckin.Api.Controllers;

public class CheckinResponse
{
    public Guid CheckinId { get; set; }
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
    public Guid LocationId { get; set; }
    public string GridReference { get; set; }
    public DateTime TimeStamp { get; set; }
}

