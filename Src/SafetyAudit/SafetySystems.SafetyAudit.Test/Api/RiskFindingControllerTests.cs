using SafetySystems.SafetyAudit.Api.Controllers;
using Shouldly;

namespace SafetySystems.SafetyAudit.Test.Api;

public class RiskFindingControllerTests
{
    [Fact]
    public void RiskFindingTests()
    {
        // Arrange
        var sut = new RiskFindingController();
        var request = new RiskFindingRequest();

        // Act
        var response = sut.PostRiskFinding(request);

        // Assert
        response.ShouldNotBeNull();
    }
}
