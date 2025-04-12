using Microsoft.AspNetCore.Mvc;
using SafetyAudit.Api.Controllers;
using System.ComponentModel.DataAnnotations;

namespace SafetySystems.SafetyAudit.Api.Controllers;

public class RiskFinding
{
}

[ApiController]
[Route("[controller]")]
public sealed class RiskFindingController : ControllerBase
{
    [HttpPost(Name = "RiskFinding")]
    public ActionResult PostRiskFinding(RiskFindingRequest riskFindingRequest)
    {
        var id = Guid.NewGuid();
        return CreatedAtRoute("GetRiskFindingById", new { riskFindingId = id });
    }

    [HttpGet(Name = "GetRiskFindingById")]
    public ActionResult<RiskFindingResponse> GetRiskFindingById([Required] Guid riskFindingId)
    {
        var resonse = new RiskFindingResponse();
        return Ok(resonse);
    }
}

public sealed class RiskFindingRequest
{
  
}

public sealed class RiskFindingResponse
{
    public Guid RiskFindingId { get; set; }
 
}
