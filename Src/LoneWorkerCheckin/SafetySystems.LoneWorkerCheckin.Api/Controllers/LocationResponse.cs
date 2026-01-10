namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class LocationResponse
{
    public Guid LocationId { get; init; }
    public string LocationName { get; init; } = string.Empty;
}
