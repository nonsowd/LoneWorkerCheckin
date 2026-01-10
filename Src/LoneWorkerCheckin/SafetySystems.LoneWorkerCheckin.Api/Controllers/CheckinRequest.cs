namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class CheckinRequest
{
    public Guid UserId { get; init; }
    public Guid SiteId { get; init; }
    public Guid LocationId { get; init; }
    public string GridReference { get; init; } = string.Empty;
}
