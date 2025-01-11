using FluentAssertions;
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
        var expectedLatitude = new Latitude((long)51.503239);
        var expectedLongitude = new Longitude((long)-0.11939357);

        // Act
        var sut = new GeoLocation(gridReference);

        // Assert
        sut.Latitude.Should().Be(expectedLatitude);
        sut.Longitude.Should().Be(expectedLongitude);
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
        sut.Should().Throw<ArgumentException>();
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
        sut.Should().NotThrow();
        result.Latitude.Should().NotBeNull();
        result.Longitude.Should().NotBeNull();
    }

}
