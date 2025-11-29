using FluentValidation;
using Microsoft.Extensions.Logging;
using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Infrastructure.DAL;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;

namespace SafetySystems.SafetyAudit.Application.SafetyInspection;

public interface IReportRiskFindingCommandHandler
{
    Result<RiskFinding> Handle(ReportRiskFindingCommand command);
}

internal sealed class ReportRiskFindingCommandHandler : IReportRiskFindingCommandHandler
{
    private readonly IRiskFindingRepository _repository;
    private readonly IValidator<RiskFinding> _validator;
    private readonly ILogger<ReportRiskFindingCommandHandler> _logger;

    public ReportRiskFindingCommandHandler (
        IValidator<RiskFinding> validator,
        IRiskFindingRepository repository,
        ILogger<ReportRiskFindingCommandHandler> logger)
    {
        _validator = validator;
        _repository = repository;
        _logger = logger;
    }
    public Result<RiskFinding> Handle(ReportRiskFindingCommand command)
    {
        var validationResult = _validator.Validate(command.RiskFinding);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var savedRiskFinding = _repository.SaveRiskFinding(command.RiskFinding);
        return Result.Success(savedRiskFinding);
    }
}
