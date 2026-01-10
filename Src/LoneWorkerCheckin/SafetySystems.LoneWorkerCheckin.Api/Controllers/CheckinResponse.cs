namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class CheckinResponse
{
    public Guid CheckinId { get; init; }
    public Guid UserId { get; init; }
    public Guid SiteId { get; init; }
    public Guid LocationId { get; init; }
    public string GridReference { get; init; } = string.Empty;
    public DateTime TimeStamp { get; init; }
}
