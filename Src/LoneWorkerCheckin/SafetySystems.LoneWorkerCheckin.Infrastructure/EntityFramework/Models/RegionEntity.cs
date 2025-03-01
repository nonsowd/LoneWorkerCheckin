namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Models;

public sealed class RegionEntity
{
    public const int RegionNameMaxLenght = 255;

    public Guid RegionId { get; set; }
    public string RegionName { get; set; } = string.Empty;
}
