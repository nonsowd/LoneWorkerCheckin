namespace LoneWorkerCheckin.Api.Controllers;

public class SiteResponse
{
    public Guid SiteId { get; set; }
    public string SiteName { get; set; } = string.Empty;

    public List<SiteLocationResponse> Locations { get; } = [];
}
