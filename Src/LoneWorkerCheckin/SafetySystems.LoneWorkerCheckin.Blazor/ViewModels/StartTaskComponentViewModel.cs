using SafetySystems.LoneWorkerCheckin.Api.Client;

namespace SafetySystems.LoneWorkerCheckin.Blazor.ViewModels;

public class StartTaskComponentViewModel
{
    private readonly ILoneWorkerCheckinApiClient _loneWorkerCheckinApiClient;

    public StartTaskComponentViewModel(ILoneWorkerCheckinApiClient loneWorkerCheckinApiClient)
        => _loneWorkerCheckinApiClient = loneWorkerCheckinApiClient;

    public List<RegionViewModel>? RegionList { get; set; }
    public string SelectedRegion { get; set; } = string.Empty;

    public List<SiteViewModel>? SiteList { get; set; }
    public string SelectedSite { get; set; } = string.Empty;

    public List<LocationViewModel>? LocationList { get; set; }
    public string SelectedLocation { get; set; } = string.Empty;


    public string TaskDescription { get; set; } = string.Empty;
    public string GPSLocation { get; set; } = string.Empty;

    public bool ShowLoading { get; set; } = false;

    public event Action OnStateHasChanged = default!;


    public async void SelectedRegionChanged(string rawSelectedRegionId)
    {
        if (Guid.TryParse(rawSelectedRegionId, out var newSelectedRegionId) == false)
        {
            throw new ArgumentException("Unable to parse selected regionId.", nameof(rawSelectedRegionId));
        }

        var response = await _loneWorkerCheckinApiClient.GetSitesByRegionAsync(newSelectedRegionId);
        // TODO: refactor duplicate code
        if (response.IsSuccessStatusCode == false)
        {
            SiteList = new List<SiteViewModel>();
            SelectedSite = string.Empty;
            RaiseStateHasChangedEvent();
            return;
        }

        SiteList = response.Content?.Select(dataItem
            => new SiteViewModel
            {
                SiteId = dataItem.SiteId.ToString(),
                SiteName = dataItem.SiteName
            })
            .ToList();

        SelectedSite = string.Empty;
        RaiseStateHasChangedEvent();
    }

    public async Task InitializedAsync()
    {
        await GetRegion();

        await GetLocations();

        RaiseStateHasChangedEvent();
    }

    private async Task GetRegion()
    {
        var response = await _loneWorkerCheckinApiClient.GetRegionListAsync();

        if (response.IsSuccessStatusCode == false)
        {
            RegionList = new List<RegionViewModel>();
            RaiseStateHasChangedEvent();
            return;
        }

        RegionList = response.Content?.Select(dataItem
            => new RegionViewModel
            {
                RegionId = dataItem.RegionId.ToString(),
                RegionName = dataItem.RegionName
            })
            .ToList();
    }

    private async Task GetLocations()
    {
        var response = await _loneWorkerCheckinApiClient.GetLocationListsAsync();

        if (response.IsSuccessStatusCode == false)
        {
            LocationList = new List<LocationViewModel>();
            RaiseStateHasChangedEvent();
            return;
        }

        LocationList = response.Content?.Select(dataItem
            => new LocationViewModel
            {
                LocationId = dataItem.LocationId.ToString(),
                LocationName = dataItem.LocationName
            })
            .ToList();
    }

    private void RaiseStateHasChangedEvent()
    {
        if (OnStateHasChanged == null)
            return;

        OnStateHasChanged();
    }
}
