namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class RegionResponse
{
    public Guid RegionId { get; init; }
    public string RegionName { get; init; } = string.Empty;
}
