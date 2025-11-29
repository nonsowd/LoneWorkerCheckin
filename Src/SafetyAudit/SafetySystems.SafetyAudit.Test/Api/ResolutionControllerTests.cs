using SafetySystems.SafetyAudit.Api.Remediation;
using Shouldly;

namespace SafetySystems.SafetyAudit.Test.Api;

public class ResolutionControllerTests
{
    [Fact]
    public void PostResolutions()
    {
        // Arrange
        var sut = new ResolutionsController();
        var request = new ResolutionsRequest();

        // Act
        var response = sut.PostResolutions(request);

        // Assert
        response.ShouldNotBeNull();
    }
}
