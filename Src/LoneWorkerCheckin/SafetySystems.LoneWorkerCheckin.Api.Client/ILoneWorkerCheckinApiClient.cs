using LoneWorkerCheckin.Api.Controllers;
using Refit;

namespace LoneWorkerCheckin.Api.Client;

public interface ILoneWorkerCheckinApiClient
{
    [Get("/user")]
    Task<ApiResponse<UserResponse>> GetUserAsync(string email);

    [Get("/site")]
    Task<ApiResponse<List<SiteResponse>>> GetSitesByRegionAsync(Guid regionId);

    [Get("/region")]
    Task<ApiResponse<List<RegionResponse>>> GetRegionListAsync();

    [Get("/location")]
    Task<ApiResponse<List<LocationResponse>>> GetLocationListsAsync();

    [Post("/checkin")]
    Task PostCheckinAsync(CheckinRequest checkin);
}
