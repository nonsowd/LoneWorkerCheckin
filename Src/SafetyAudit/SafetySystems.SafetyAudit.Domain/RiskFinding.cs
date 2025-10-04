namespace SafetySystems.SafetyAudit.Domain;

public sealed class RiskFinding
{
    public Guid RiskFindingId { get; init; }
    public Guid SiteId { get; set; }
    public Guid AuditorId { get; set; }
    public Guid SpecificIssueRiskId { get; set; }
    public Guid RiskCodeId { get; set; }
    public IssuesStatusEnum IssuesStatus { get; set; } = IssuesStatusEnum.Open;
    public DateTime DateOfInspection { get; set; }
    public string RiskDescription { get; set; } = string.Empty;
}
