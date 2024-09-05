using System.Runtime.CompilerServices;
using LoneWorkerCheckin.Api.Client;
using LoneWorkerCheckin.Api.Controllers;

namespace LoneWorkerCheckin.Blazor.ViewModels;

public class CheckinPageViewModel
{
    private readonly ILoneWorkerCheckinApiClient _loneWorkerCheckinApiClient;

    public CheckinPageViewModel(ILoneWorkerCheckinApiClient loneWorkerCheckinApiClient)
    {
        _loneWorkerCheckinApiClient = loneWorkerCheckinApiClient;
    }

    public string PageTitle => "Checkin";

    public List<RegionViewModel>? RegionList { get; set; }
    public List<SiteViewModel>? SiteList { get; set; }
    public List<LocationViewModel>? LocationList { get; set; }

    public string TaskDescription { get; set; }

    public bool ShowLoading { get; set; } = false;


    public async void OnSelectedRegionChanged(string rawSelectedRegionId)
    {
        if (Guid.TryParse(rawSelectedRegionId, out var newSelectedRegionId) == false)
        {
            throw new ArgumentException("Unable to parse selected regionId.",nameof(rawSelectedRegionId));
        }
            
        var response = await _loneWorkerCheckinApiClient.GetSitesByRegionAsync(newSelectedRegionId);

        SiteList = response.Select(dataItem
            => new SiteViewModel()
            {
                SiteId = dataItem.SiteId.ToString(),
                SiteName = dataItem.SiteName
            })
            .ToList();
    }

    public string SelectedRegion { get; set; }

    public async Task OnInitializedAsync()
    {
        await GetRegion();

        await GetLocations();
       
    }

    private async Task GetRegion()
    {
        var response = await _loneWorkerCheckinApiClient.GetRegionListAsync();
        RegionList = response.Select(dataItem
            => new RegionViewModel()
            {
                RegionId = dataItem.RegionId.ToString(),
                RegionName = dataItem.RegionName
            })
            .ToList();
    }

    private async Task GetLocations()
    {
        var response = await _loneWorkerCheckinApiClient.GetLocationListsAsync();
        LocationList = response.Select(dataItem
            => new LocationViewModel()
            {
                LocationId = dataItem.LocationId.ToString(),
                LocationName = dataItem.LocationName
            })
            .ToList();

    }
}

