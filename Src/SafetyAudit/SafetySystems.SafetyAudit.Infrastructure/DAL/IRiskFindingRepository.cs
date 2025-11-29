using SafetySystems.SafetyAudit.Domain;

namespace SafetySystems.SafetyAudit.Infrastructure.DAL;

public interface IRiskFindingRepository
{
    RiskFinding SaveRiskFinding(RiskFinding riskFinding);
}
