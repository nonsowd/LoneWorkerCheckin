#if DESIGN
using LoneWorkerCheckin.Api.Controllers;

namespace LoneWorkerCheckin.Api.Client;

public sealed class DesignTimeLoneWorkerCheckinApiClient : ILoneWorkerCheckinApiClient
{
    public Task<List<LocationResponse>> GetLocationListsAsync()
        => Task.FromResult(new List<LocationResponse>()
        {
            new() { LocationId = Guid.NewGuid(), LocationName = "Front gate" },
            new() { LocationId = Guid.NewGuid(), LocationName = "Back gate" },
            new() { LocationId = Guid.NewGuid(), LocationName = "Garage" },
        });
    public Task<List<RegionResponse>> GetRegionListAsync()
        => Task.FromResult(new List<RegionResponse>()
        {
            new() { RegionId = Guid.NewGuid(), RegionName = "Wales" },
            new() { RegionId = Guid.NewGuid(), RegionName = "South East" },
            new() { RegionId = Guid.NewGuid(), RegionName = "South West" },
            new() { RegionId = Guid.NewGuid(), RegionName = "Southern" },
            new() { RegionId = Guid.NewGuid(), RegionName = "Northern" },
            new() { RegionId = Guid.NewGuid(), RegionName = "Scotland" },
            new() { RegionId = Guid.NewGuid(), RegionName = "Middle England" },
        });
    public Task<List<SiteResponse>> GetSitesByRegionAsync(Guid regionId)
        => Task.FromResult(new List<SiteResponse>()
        {
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 1"},
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 2"},
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 3"},
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 4"},
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 5"},
            new() {SiteId = Guid.NewGuid(), SiteName = "Site 6"},
        });
    public Task<UserResponse> GetUserAsync(string email)
        => Task.FromResult(new UserResponse ());
    public Task PostCheckinAsync(CheckinRequest checkin)
        => Task.CompletedTask;

}
#endif // DESIGN


