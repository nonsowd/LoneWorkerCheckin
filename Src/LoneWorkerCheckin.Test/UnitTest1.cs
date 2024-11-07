using LoneWorkerCheckin.Domain;

namespace LoneWorkerCheckin.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var lat = new Latitude(32424353546464);
        var lng = new Longitude(3242435354633464);
        var moo = new GeoLocation(lng, lat);

    }
}
