namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Models;

public sealed class CheckinEntity
{
    public Guid CheckinId { get; set; }
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
    public Guid LocationId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime TimeStamp { get; set; }
}



