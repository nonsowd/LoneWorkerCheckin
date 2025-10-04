using SafetySystems.SafetyAudit.Api.SafetyInspection;
using Shouldly;

namespace SafetySystems.SafetyAudit.Test.Api;

public class SiteInspectionReportControllerTests
{
    [Fact]
    public void PostSiteInspectionReport()
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
