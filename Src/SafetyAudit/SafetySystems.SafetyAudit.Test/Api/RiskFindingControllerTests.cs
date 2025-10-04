using Microsoft.AspNetCore.Mvc;
using Shouldly;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Moq;
using SafetySystems.SafetyAudit.Api.SafetyInspection;
using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Infrastructure.DAL;

namespace SafetySystems.SafetyAudit.Test.Api;

public class RiskFindingControllerTests
{
    private readonly Mock<IValidator<RiskFinding>> _mockValidator = new();
    private readonly Mock<IRiskFindingRepository> _mockRepository = new();
    private readonly Mock<ILogger<RiskFindingController>> _mockLogger = new();

    [Fact]
    public void PostRiskFinding_Returns_RiskFindingResponse_Given_ValidRiskFindingRequest()
    {
        // Arrange
        _mockValidator.Setup(x => x.Validate(It.IsAny<RiskFinding>()))
            .Returns(new ValidationResult());

        var databaseRiskFindingId = Guid.NewGuid();
        _mockRepository.Setup(x => x.SaveRiskFinding(It.IsAny<RiskFinding>()))
            .Returns(new RiskFinding { RiskFindingId = databaseRiskFindingId });

        var sut = new RiskFindingController(_mockValidator.Object, _mockRepository.Object, _mockLogger.Object);
        var request = new RiskFindingRequest();
        request.AuditorId = Guid.NewGuid();
        request.SpecificIssueRiskId = Guid.NewGuid();
        request.RiskCodeId = Guid.NewGuid();
        request.DateOfInspection = DateTime.Now;
        request.RiskDescription = Guid.NewGuid().ToString();

        // Act
        var response = sut.PostRiskFinding(request);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<ActionResult<Guid>>();
        response.Result.ShouldBeOfType<CreatedAtRouteResult>();
        response.Value.ShouldBeEquivalentTo(Guid.Empty);
        var result = (CreatedAtRouteResult)response.Result;
        result.Value.ShouldBeEquivalentTo(databaseRiskFindingId);
        _mockRepository.Verify(x=>x.SaveRiskFinding(It.IsAny<RiskFinding>()), Times.Once);
    }

    [Fact]
    public void PostRiskFinding_Returns_BadRequestResponse_Given_InvalidRiskFindingRequest()
    {
        // Arrange
        _mockValidator.Setup(x => x.Validate(It.IsAny<RiskFinding>()))
            .Returns(new ValidationResult
            {
                Errors = new List<ValidationFailure> {new ValidationFailure("AuditID", "Must be a valid GUID.")}
            });

        var sut = new RiskFindingController(_mockValidator.Object, _mockRepository.Object, _mockLogger.Object);
        var request = new RiskFindingRequest();

        // Act
        var response = sut.PostRiskFinding(request);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<ActionResult<Guid>>();
        response.Result.ShouldBeOfType<BadRequestObjectResult>();
        response.Value.ShouldBeEquivalentTo(Guid.Empty) ;
        _mockRepository.Verify(x=>x.SaveRiskFinding(It.IsAny<RiskFinding>()), Times.Never);
    }
}
