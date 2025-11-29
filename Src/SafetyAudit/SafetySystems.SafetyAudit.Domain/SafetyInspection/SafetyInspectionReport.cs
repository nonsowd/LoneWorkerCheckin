namespace SafetySystems.SafetyAudit.Domain.SafetyInspection
{
    public class SafetyInspectionReport
    {
        public IReadOnlyList<RiskFinding> RiskFindings { get; }
        public double AverageRiskLevel { get; private set; } = 0;

        public SafetyInspectionReport()
        {
            this.RiskFindings = new List<RiskFinding>()
            {
                new RiskFinding() { RiskFindingId = Guid.NewGuid(), RiskLevel = RiskLevelEnum.Low, },
                new RiskFinding() { RiskFindingId = Guid.NewGuid(), RiskLevel = RiskLevelEnum.Medium, },
                new RiskFinding() { RiskFindingId = Guid.NewGuid(), RiskLevel = RiskLevelEnum.High, }
            };
        }

        public void Compute()
            => AverageRiskLevel = RiskFindings.Average(x => (int)x.RiskLevel);
    }
}
