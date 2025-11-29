using SafetySystems.SafetyAudit.Domain;

namespace SafetySystems.SafetyAudit.Application.SafetyInspection;

public sealed class ReportRiskFindingCommand
{
    public ReportRiskFindingCommand(RiskFinding riskFinding)
    {
        RiskFinding = riskFinding;
    }

    public RiskFinding RiskFinding { get; }
}
