using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SafetyAudit.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ResolutionsController : ControllerBase
{
    [HttpPost(Name = "Resolutions")]
    public ActionResult PostResolutions(ResolutionsRequest resolutionsReport)
    {
        var id = Guid.NewGuid();
        return CreatedAtRoute("GetResolutionsById", new { resolutionsId = id });
    }

    [HttpGet(Name = "GetResolutionsById")]
    public ActionResult <ResolutionsResponse> GetResolutionsById ([Required] Guid resolutionsId)
    {
        var resonse = new ResolutionsResponse();
        return Ok(resonse);
    }
}

public sealed class ResolutionsRequest
{
    public Guid SiteInspectionReportId { get; set; }
    public DateTime DateOfResolutions { get; set; }
    public Guid IssueId { get; set; }
    [Required]
    public string ResolutionDetails { get; set; } = string.Empty;
    public Guid ResolutionStatusId { get; set; }
}

public sealed class ResolutionsResponse
{
    public Guid ResolutionsId { get; set; }
    public Guid SiteInspectionReportId { get; set; }
    public DateTime DateOfResolutions { get; set; }
    public Guid IssueId { get; set; }
    [Required]
    public string ResolutionDetails { get; set; } = string.Empty;
    public Guid ResolutionStatusId { get; set; }
}
