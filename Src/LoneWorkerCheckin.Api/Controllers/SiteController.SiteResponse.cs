namespace LoneWorkerCheckin.Api.Controllers;

public class SiteResponse
{
    public Guid SiteId { get; set; }
    public string SiteName { get; set; } = string.Empty;

    public List<SiteArea> Areas { get; } = [];

    public class SiteArea
    {
        public Guid AreaID { get; set; }
        public string AreaName { get; set; } = string.Empty;
    }
}
