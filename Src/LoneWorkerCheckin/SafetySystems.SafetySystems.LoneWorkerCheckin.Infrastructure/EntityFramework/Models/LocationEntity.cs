namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Models;

public sealed class LocationEntity
{
    public const int LocationNameMaxLenght = 255;

    public Guid LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
}
