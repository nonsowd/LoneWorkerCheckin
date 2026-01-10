namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class SiteResponse
{
    public Guid SiteId { get; init; }
    public string SiteName { get; init; } = string.Empty;
}
