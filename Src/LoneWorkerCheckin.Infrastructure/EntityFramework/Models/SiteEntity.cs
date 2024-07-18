namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Models;

internal class SiteEntity 
{
    public const int SiteNameMaxLenght = 255;

    public Guid SiteId { get; set; }
    public Guid RegionId { get; set; }

    public string SiteName { get; set; } = string.Empty;

    public RegionEntity Region { get; internal set; } = null!;
}
