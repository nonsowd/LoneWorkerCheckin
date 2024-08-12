using LoneWorkerCheckin.Api.Controllers;
using Refit;

namespace LoneWorkerCheckin.Api.Client;

public interface ILoneWorkerCheckinApiClient
{
    [Get("/user")]
    Task<UserResponse> GetUserAsync(string email);

    [Get("/site")]
    Task<List<SiteResponse>> GetSitesByRegionAsync(Guid regionId);

    [Get("/region")]
    Task<List<RegionResponse>> GetRegionListAsync();

    [Get("/location")]
    Task<List<LocationResponse>> GetLocationBySiteAsync(Guid siteId);

    [Post("/checkin")]
    Task PostCheckinAsync(CheckinRequest checkin);
}
