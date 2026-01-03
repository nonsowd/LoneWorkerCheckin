using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SafetySystems.SafetyAudit.Api.SafetyInspection;

[ApiController]
[Route("[controller]")]
public sealed class SiteInspectionReportController : ControllerBase
{
    [HttpPost(Name = "SiteInspectionReport")]
    public ActionResult PostSiteInspectionReport(SiteInspectionReportRequest siteInspectionReport)
    {
        var id = Guid.NewGuid();
        return CreatedAtRoute("GetSiteInspectionReportById", new { siteInspectionReportId = id });
    }

    [HttpGet(Name = "GetSiteInspectionReportById")]
    public ActionResult<SiteInspectionReportResponse> GetSiteInspectionReportById([Required] Guid siteInspectionReportId)
    {
        var response = new SiteInspectionReportResponse();
        return Ok(response);
    }
}

public sealed class SiteInspectionReportRequest
{
    public Guid SiteId { get; init; }
    public Guid AuditorId { get; init; }
    public DateTime DateOfInspection { get; init; }
    public IEnumerable<SiteInspectionIssues> SiteInspectionIssues { get; init; } = [];
}

public sealed class SiteInspectionReportResponse
{
    public Guid SiteInspectionReportId { get; init; }
    public Guid SiteId { get; init; }
    public Guid AuditorId { get; init; }
    public DateTime DateOfInspection { get; init; }
    public IEnumerable<SiteInspectionIssues> SiteInspectionIssues { get; init; } = [];
}

public sealed class SiteInspectionIssues
{
    public Guid IssueId { get; init; }
    public Guid RiskId { get; init; }
    public Guid SpecificIssueRiskId { get; init; }
    public string RiskDescription { get; init; } = string.Empty;
    public Guid RiskCodeId { get; init; }
    public Guid IssuesStatusId { get; init; }
    public DateTime DateOfInspection { get; init; }
}
