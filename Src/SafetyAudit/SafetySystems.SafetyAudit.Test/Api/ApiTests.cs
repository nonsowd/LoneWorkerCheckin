using SafetyAudit.Api.Controllers;
using SafetySystems.SafetyAudit.Api.Controllers;
using Shouldly;

namespace SafetySystems.SafetyAudit.Test.Api;

public class ApiTests
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

    [Fact]
    public void ResolutionControllerTests()
    {
        // Arrange
        var sut = new ResolutionsController();
        var request = new ResolutionsRequest();

        // Act
        var response = sut.PostResolutions(request);

        // Assert
        response.ShouldNotBeNull();
    }

    [Fact]
    public void SiteInspectionReportControllerTests()
    {
        // Arrange
        var sut = new SiteInspectionReportController();
        var request = new SiteInspectionReportRequest();

        // Act
        var response = sut.PostSiteInspectionReport(request);

        // Assert
        response.ShouldNotBeNull();
    }
}
