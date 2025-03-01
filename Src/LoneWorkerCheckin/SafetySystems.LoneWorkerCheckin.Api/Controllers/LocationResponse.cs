namespace LoneWorkerCheckin.Api.Controllers;

public sealed class LocationResponse
{
    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
}
