using Shouldly;
using LoneWorkerCheckin.Domain;

namespace LoneWorkerCheckin.Test.Domain;

public class GeoLocation_Ctor
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_CreateAValidGeoLocation_Given_AValidGridReference()
    {
        // Arrange
        var gridReference = "51.503239,-0.11939357";
        var expectedLatitude = new Latitude(51.503239);
        var expectedLongitude = new Longitude(-0.11939357);

        // Act
        var sut = new GeoLocation(gridReference);

        // Assert
        sut.Latitude.ShouldBe(expectedLatitude);
        sut.Longitude.ShouldBe(expectedLongitude);
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ThrowAnExecption_Given_AGridRefereneWithoutComma()
    {
        // Arrange
        var gridReference = "51.503239-0.11939357";

        // Act
        var sut = () => new GeoLocation(gridReference);

        // Assert
        sut.ShouldThrow<ArgumentException>();
    }

    [Theory]
    [Trait("Category", "UnitTest")]
    [InlineData("51.503239,-0.1193935 7")]
    [InlineData("5 1.503239,-0.11939357")]
    [InlineData("51.503239, -0.11939357")]
    [InlineData("51.503239,- 0.11939357")]
    [InlineData("51.50 3239,-0.11939357")]
    [InlineData("51. 503239,-0.11939357")]
    [InlineData("51.503239 ,-0.11939357")]
    [InlineData("51.503 239,-0.1193 9357")]
    [InlineData(" 51.503239,-0.11939357")]
    [InlineData("51.503239,-0.11939357 ")]
    [InlineData("  51.503239,-0.11939357")]
    [InlineData("51.503239,-0.11939357  ")]
    [InlineData("   51.503239,-0.11939357   ")]
    [InlineData(" 51.503239 , -0.11939357 ")]
    public void Should_NotThrowAnExecption_Given_AGridRefereneWithWhiteSpaces(string value)
    {
        // Arrange
        var gridReference = value;

        // Act
        var sut = () => new GeoLocation(gridReference);
        var result = sut.Invoke();

        // Assert
        sut.ShouldNotThrow();
        result.Latitude.ShouldNotBeNull();
        result.Longitude.ShouldNotBeNull();
    }
}

public class GeoLocation_ToString
{

    [Theory]
    [Trait("Category", "UnitTest")]
    [InlineData("51.503239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239,-0.11939666", "51.503239,-0.11939666")]
    [InlineData("51.503239,-0.1193935 7", "51.503239,-0.11939357")]
    [InlineData("5 1.503239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239, -0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239,- 0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.50 3239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51. 503239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239 ,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503 239,-0.1193 9357", "51.503239,-0.11939357")]
    [InlineData(" 51.503239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239,-0.11939357 ", "51.503239,-0.11939357")]
    [InlineData("  51.503239,-0.11939357", "51.503239,-0.11939357")]
    [InlineData("51.503239,-0.11939357  ", "51.503239,-0.11939357")]
    [InlineData("   51.503239,-0.11939357   ", "51.503239,-0.11939357")]
    [InlineData(" 51.503239 , -0.11939357 ", "51.503239,-0.11939357")]
    public void Should_Foo_Given_Moo(string value, string expectedOutPut)
    {
        // Arrange
        var gridReference = value;

        // Act
        var sut = () => new GeoLocation(gridReference);
        var geolocation = sut.Invoke();
        var result = geolocation.ToString();

        // Assert
        sut.ShouldNotThrow();
        geolocation.Latitude.ShouldNotBeNull();
        geolocation.Longitude.ShouldNotBeNull();
        result.ShouldBe(expectedOutPut);
    }

}


