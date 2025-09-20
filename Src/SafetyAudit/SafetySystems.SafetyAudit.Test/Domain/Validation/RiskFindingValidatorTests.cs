using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Domain.Validation;
using Shouldly;

namespace SafetySystems.SafetyAudit.Test.Domain.Validation
{
    public class RiskFindingValidatorTests
    {
        [Fact]
        public void RiskFindingValidator_Validate_Should_ReturnValidWithOutErrors_Given_AValid_RiskFinding()
        {
            // Arrange
            var sut = new RiskFindingValidator();
            var riskFinding = new RiskFinding()
            {
                SiteId = Guid.NewGuid(),
                AuditorId = Guid.NewGuid(),
                SpecificIssueRiskId = Guid.NewGuid(),
                RiskCodeId = Guid.NewGuid(),
                IssuesStatus = IssuesStatusEnum.Open,
                DateOfInspection = DateTime.Now,
                RiskDescription = "Moo"
            };

            // Act
            var validationResult = sut.Validate(riskFinding);

            // Assert
            validationResult.ShouldNotBeNull();
            validationResult.IsValid.ShouldBeTrue();
            validationResult.Errors.Count.ShouldBe(0);
        }
    }
}
