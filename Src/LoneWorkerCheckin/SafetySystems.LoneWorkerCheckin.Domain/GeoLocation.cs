namespace LoneWorkerCheckin.Domain;

/*
 TQ306799

eastings northings
530624 , 179932

long         lat
51.503239 , -0.11939357

long	     lat (degs, mins, secs)
51°30′12″N , 000°07′10″W


what3words
bunch.keen.adopt

https://gridreferencefinder.com/os.php?gr=TQ3062479932|Point_s_F|1&t=Point%20F&v=r

 */

public record GeoLocation
{
    public Latitude Latitude { get; set; }
    public Longitude Longitude { get; set; }

    public GeoLocation(Longitude longitude, Latitude latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }

    public GeoLocation(string gridReference)
    {
        try
        {
            //"51.503239,-0.11939357"
            var rawGridReferenceParts = gridReference.Split(',');
            var rawstringLat = rawGridReferenceParts[0].Replace(" ", "");
            var rawstringLng = rawGridReferenceParts[1].Replace(" ", "");

            var lat = double.Parse(rawstringLat);
            var lng = double.Parse(rawstringLng);

            Latitude = new Latitude(lat);
            Longitude = new Longitude(lng);
        }
        catch (IndexOutOfRangeException ex)
        {
            throw new ArgumentException("No comma", nameof(gridReference), ex);
        }
    }

    public override string ToString() => $"{Latitude},{Longitude}";
}
