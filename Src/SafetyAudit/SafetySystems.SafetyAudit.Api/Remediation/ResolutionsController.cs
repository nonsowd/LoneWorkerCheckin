using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace SafetySystems.SafetyAudit.Api.Remediation;

[ApiController]
[Route("[controller]")]
public sealed class ResolutionsController : ControllerBase
{
    [HttpPost(Name = "Resolutions")]
    public ActionResult PostResolutions(ResolutionsRequest resolutionsRequest)
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
    public Guid SiteInspectionReportId { get; init; }
    public DateTime DateOfResolutions { get; init; }
    public Guid RiskFindingId { get; init; }
    public string ResolutionDetails { get; init; } = string.Empty;
    public Guid ResolutionStatusId { get; init; }
}

public sealed class ResolutionsResponse
{
    public Guid ResolutionsId { get; init; }
    public Guid SiteInspectionReportId { get; init; }
    public DateTime DateOfResolutions { get; init; }
    public Guid RiskFindingId { get; init; }
    public string ResolutionDetails { get; init; } = string.Empty;
    public Guid ResolutionStatusId { get; init; }
}
