using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Microsoft.Extensions.Logging;
using Moq;
using SafetySystems.SafetyAudit.Api.SafetyInspection;
using SafetySystems.SafetyAudit.Application.SafetyInspection;
using SafetySystems.SafetyAudit.Domain;

namespace SafetySystems.SafetyAudit.Test.Api;

public class RiskFindingControllerTests
{
    private readonly Mock<ILogger<RiskFindingController>> _mockLogger = new();
    private readonly Mock<IReportRiskFindingCommandHandler> _mockCommandHandler = new();

    [Fact]
    public void PostRiskFinding_Returns_RiskFindingResponse_Given_ValidRiskFindingRequest()
    {
        // Arrange
        var databaseRiskFindingId = Guid.NewGuid();

        _mockCommandHandler.Setup(x => x.Handle(It.IsAny<ReportRiskFindingCommand>()))
            .Returns(Result.Success(new RiskFinding { RiskFindingId = databaseRiskFindingId }));

        var sut = new RiskFindingController(_mockLogger.Object, _mockCommandHandler.Object);
        var request = new RiskFindingRequest
        {
            SiteId = Guid.NewGuid(),
            AuditorId = Guid.NewGuid(),
            SpecificIssueRiskId = Guid.NewGuid(),
            RiskCodeId = Guid.NewGuid(),
            IssuesStatus = IssuesStatusEnum.Open,
            DateOfInspection = DateTime.Now,
            RiskDescription = Guid.NewGuid().ToString()
        };

        // Act
        var response = sut.PostRiskFinding(request);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<ActionResult<Guid>>();
        response.Result.ShouldBeOfType<CreatedAtRouteResult>();
        response.Value.ShouldBeEquivalentTo(Guid.Empty);
        var result = (CreatedAtRouteResult)response.Result;
        result.Value.ShouldBeEquivalentTo(databaseRiskFindingId);
    }

    [Fact]
    public void PostRiskFinding_Returns_BadRequestResponse_Given_InvalidRiskFindingRequest()
    {
        // Arrange
        _mockCommandHandler.Setup(x => x.Handle(It.IsAny<ReportRiskFindingCommand>()))
            .Returns(Result.Invalid(new ValidationError("AuditID", "Must be a valid GUID.")));

        var sut = new RiskFindingController(_mockLogger.Object, _mockCommandHandler.Object);
        var request = new RiskFindingRequest();

        // Act
        var response = sut.PostRiskFinding(request);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<ActionResult<Guid>>();
        response.Result.ShouldBeOfType<BadRequestObjectResult>();
        response.Value.ShouldBeEquivalentTo(Guid.Empty) ;
    }
}
