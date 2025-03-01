using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SafetyAudit.Api.Controllers;

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
    public Guid SiteId { get; set; }
    public Guid AuditorId { get; set; }
    public DateTime DateOfInspection { get; set; }
    public IEnumerable<SiteInspectionIssues> SiteInspectionIssues { get; set; } = [];
}

public sealed class SiteInspectionReportResponse
{
    public Guid SiteInspectionReportId { get; set; }
    public Guid SiteId { get; set; }
    public Guid AuditorId { get; set; }
    public DateTime DateOfInspection { get; set; }
    public IEnumerable<SiteInspectionIssues> SiteInspectionIssues { get; set; } = [];
}

public sealed class SiteInspectionIssues
{
    public Guid IssueId { get; set; }
    public Guid RiskId { get; set; }
    public Guid SpecificIssueRiskId { get; set; }
    [Required]
    public string RiskDescription { get; set; } = string.Empty;
    public Guid RiskCodeId { get; set; }
    public Guid IssuesStatusId { get; set; }
    public DateTime DateOfInspection { get; set; }
}
