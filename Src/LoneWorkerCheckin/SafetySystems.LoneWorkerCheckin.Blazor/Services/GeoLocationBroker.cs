using Microsoft.JSInterop;

namespace LoneWorkerCheckin.Blazor.Services;

public struct Coordinate
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Accuracy { get; set; }

    public override string ToString() => $"Lat: {Latitude}, Long: {Longitude}";
}

public struct GeolocationPositionError
{
    public string Message { get; set; }
    public int Code { get; set; }
}

public interface IGeoLocationBroker
{
    ValueTask RequestGeoLocationAsync();
    ValueTask RequestGeoLocationAsync(bool enableHighAccuracy, int maximumAgeInMilliseconds);

    event Func<Coordinate, ValueTask> OnCoordinatesChanged;

    event Func<GeolocationPositionError, ValueTask> OnGeolocationPositionError;
}

public class GeoLocationBroker : IGeoLocationBroker
{
    private readonly IJSRuntime jsRuntime;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private readonly DotNetObjectReference<GeoLocationBroker> dotNetObjectReference;

    public GeoLocationBroker(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;

        moduleTask = new(() => this.jsRuntime!.InvokeAsync<IJSObjectReference>(
            identifier: "import",
            args: "./scripts/geoLocationJsInterop.js")
        .AsTask());

        dotNetObjectReference = DotNetObjectReference.Create(this);
    }

    public async ValueTask RequestGeoLocationAsync(bool enableHighAccuracy, int maximumAgeInMilliseconds)
    {
        var module = await moduleTask.Value;
        var dotNetObjectReference = this.dotNetObjectReference;

        await module.InvokeVoidAsync(identifier: "getCurrentPosition",
                                     dotNetObjectReference,
                                     enableHighAccuracy,
                                     maximumAgeInMilliseconds);
    }

    public async ValueTask RequestGeoLocationAsync()
    {
        await RequestGeoLocationAsync(enableHighAccuracy: true, maximumAgeInMilliseconds: 0);
    }

    public event Func<Coordinate, ValueTask> OnCoordinatesChanged = default!;

    public event Func<GeolocationPositionError, ValueTask> OnGeolocationPositionError = default!;

    [JSInvokable]
    public async Task OnSuccessAsync(Coordinate coordinates)
    {
        await OnCoordinatesChanged.Invoke(coordinates);
    }

    [JSInvokable]
    public async Task OnErrorAsync(GeolocationPositionError error)
    {
        await OnGeolocationPositionError.Invoke(error);
    }
}
