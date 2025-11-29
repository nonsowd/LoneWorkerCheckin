namespace SafetySystems.LoneWorkerCheckin.Api.Controllers;

public sealed class RegionResponse
{
    public Guid RegionId { get; set; }
    public string RegionName { get; set; } = string.Empty;
}
