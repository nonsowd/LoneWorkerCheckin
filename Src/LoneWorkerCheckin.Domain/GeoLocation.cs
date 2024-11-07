namespace LoneWorkerCheckin.Domain;

public record GeoLocation
{
    public Latitude Latitude { get; set; }
    public Longitude Longitude { get; set; }

    public GeoLocation(Longitude longitude, Latitude latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }
}

public record Latitude (long Value);
public record Longitude (long Value);
