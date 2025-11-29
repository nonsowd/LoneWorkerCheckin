using SafetySystems.SafetyAudit.Domain;

namespace SafetySystems.SafetyAudit.Infrastructure.DAL;

public class RiskFindingRepository : IRiskFindingRepository
{
    public RiskFinding SaveRiskFinding(RiskFinding riskFinding)
    {
        var result = new RiskFinding
        {
            // TODO: Implement DAL

            RiskFindingId = Guid.NewGuid(),
            SiteId = riskFinding.SiteId,
            AuditorId = riskFinding.AuditorId,
            SpecificIssueRiskId = riskFinding.SpecificIssueRiskId,
            RiskCodeId = riskFinding.RiskCodeId,
            IssuesStatus = riskFinding.IssuesStatus,
            DateOfInspection = riskFinding.DateOfInspection,
            RiskDescription = riskFinding.RiskDescription,
        };
        return result;
    }
}
