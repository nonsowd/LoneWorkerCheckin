using FluentValidation;

namespace SafetySystems.SafetyAudit.Domain.Validation;

//TODO : Change class to internal and dependency injection
public sealed class RiskFindingValidator: AbstractValidator<RiskFinding>
{
    public RiskFindingValidator()
    {
        RuleFor(x => x.AuditorId).NotEmpty();
        RuleFor(x => x.SpecificIssueRiskId).NotEmpty();
        RuleFor(x => x.RiskCodeId).NotEmpty();
        RuleFor(x => x.DateOfInspection).NotEmpty();
        RuleFor(x => x.RiskDescription).NotEmpty();
    }
}
