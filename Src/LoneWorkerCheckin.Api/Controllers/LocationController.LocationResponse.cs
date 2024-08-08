namespace LoneWorkerCheckin.Api.Controllers;

public class LocationResponse
{
    public Guid LocationId { get; set; }
    public Guid? SiteId { get; set; }
    public string LocationName { get; set; } = string.Empty;
}
