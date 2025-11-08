using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SafetySystems.SafetyAudit.Application.SafetyInspection;
using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Infrastructure.DAL;

namespace SafetySystems.SafetyAudit.Api.SafetyInspection;

[ApiController]
[Route("[controller]")]
public sealed class RiskFindingController : ControllerBase
{
    private readonly ILogger<RiskFindingController> _logger;
    private readonly IReportRiskFindingCommandHandler _commandHandler;

    public RiskFindingController (
        ILogger<RiskFindingController> logger,
        IReportRiskFindingCommandHandler commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    [HttpPost(Name = "RiskFinding")]
    [EndpointDescription("Persists a valid RiskFinding request to the data store.")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RiskFindingResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public ActionResult<Guid> PostRiskFinding(RiskFindingRequest riskFindingRequest)
    {
        _logger.LogInformation("Post riskfinding site id: {request.SiteId}", riskFindingRequest.SiteId);

        var command = new ReportRiskFindingCommand(riskFindingRequest.ToRiskFinding());
        var commmandResult = _commandHandler.Handle(command);

        if (!commmandResult.IsSuccess)
        {
            commmandResult.ValidationErrors.ToList().ForEach((err) => ModelState.AddModelError(err.Identifier, err.ErrorMessage));
            return BadRequest(ModelState);
        }

        var savedRiskFinding = commmandResult.Value;
        return CreatedAtRoute("GetRiskFindingById", new { riskFindingId = savedRiskFinding.RiskFindingId }, savedRiskFinding.RiskFindingId);
    }

    [HttpGet(Name = "GetRiskFindingById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RiskFindingResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RiskFindingResponse> GetRiskFindingById([Required] Guid riskFindingId)
    {
        var response = new RiskFindingResponse();
        return Ok(response);
    }
}


public sealed class RiskFindingRequest
{
    public Guid SiteId { get; set; }
    public Guid AuditorId { get; set; }
    public Guid SpecificIssueRiskId { get; set; }
    public Guid RiskCodeId { get; set; }
    public IssuesStatusEnum IssuesStatus { get; set; } = IssuesStatusEnum.Open;
    public DateTime DateOfInspection { get; set; }
    public string RiskDescription { get; set; } = string.Empty;
}


public sealed class RiskFindingResponse
{
    public Guid RiskFindingId { get; set; }

}

public static class RiskFindingMapper
{
    public static RiskFinding ToRiskFinding(this RiskFindingRequest request)
    {
        return new RiskFinding
        {
            SiteId = request.SiteId,
            AuditorId = request.AuditorId,
            SpecificIssueRiskId = request.SpecificIssueRiskId,
            RiskCodeId = request.RiskCodeId,
            IssuesStatus = request.IssuesStatus,
            DateOfInspection = request.DateOfInspection,
            RiskDescription = request.RiskDescription,
        };
    }
}
