using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Infrastructure.DAL;

namespace SafetySystems.SafetyAudit.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class RiskFindingController : ControllerBase
{
    private readonly IRiskFindingRepository _repository;
    private readonly IValidator<RiskFinding> _validator;
    private readonly ILogger<RiskFindingController> _logger;
    public RiskFindingController (
        IValidator<RiskFinding> validator,
        IRiskFindingRepository repository,
        ILogger<RiskFindingController> logger)
    {
        _validator = validator;
        _repository = repository;
        _logger = logger;
    }

    [HttpPost(Name = "RiskFinding")]
    [EndpointDescription("Persists a valid RiskFinding request to the data store.")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RiskFindingResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public ActionResult PostRiskFinding(RiskFindingRequest riskFindingRequest)
    {

        _logger.LogInformation("Post riskfinding site id: {request.SiteId}", riskFindingRequest.SiteId);

        //Todo: Add response attributes

        var riskFinding = new RiskFinding
        {
            SiteId = riskFindingRequest.SiteId,
            AuditorId = riskFindingRequest.AuditorId,
            SpecificIssueRiskId = riskFindingRequest.SpecificIssueRiskId,
            RiskCodeId = riskFindingRequest.RiskCodeId,
            IssuesStatus = riskFindingRequest.IssuesStatus,
            DateOfInspection = riskFindingRequest.DateOfInspection,
            RiskDescription = riskFindingRequest.RiskDescription,
        };

        var validationResult = _validator.Validate(riskFinding);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var savedRiskFinding = _repository.SaveRiskFinding(riskFinding);

        return CreatedAtRoute("GetRiskFindingById", new { riskFindingId = Guid.NewGuid() });
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
