using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RequestController(WMSContext context) : BaseApiController
{
    

    [HttpGet]
    public async Task<ActionResult<List<Request>>> GetRequests([FromQuery] RequestParams requestParams)
    {
        var query = context.Requests
            .Sort(requestParams.OrderBy)
            .Search(requestParams.SearchTerm)
            .Filter(requestParams.RequestType, requestParams.Priority)
            .AsQueryable();

        var pagedList = await PagedList<Request>.ToPagedList(query, 
            requestParams.PageNumber, requestParams.PageSize);

        return pagedList;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
        var request = await context.Requests.FindAsync(id);

        if (request == null)
            return NotFound();

        return request;
    }

    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters()
    {
        var requestTypes = await context.RequestTypes.Select(p => p.RequestTypeName).Distinct().ToListAsync();
        var priorities = await context.Priorities.Select(p => p.PriorityName).Distinct().ToListAsync();

        return Ok(new { requestTypes, priorities });
    }

    [HttpPost]
    public async Task<ActionResult<Request>> AddRequest(CreateRequestDto requestDto)
    {
        
        var request = new Request
        {
            RequestedDate = DateTime.Now,
            RequestTitle = requestDto.RequestTitle,
            RequestDescription = requestDto.RequestDescription,
            RequestedBy = requestDto.RequestedBy,
            Department = requestDto.Department,
            ExplainImpact = requestDto.ExplainImpact,
            hasStakeHolderConferred = requestDto.HasStakeHolderConferred,
            ProposedImpDate = requestDto.ProposedImpDate,
            
            BoardDate = requestDto.BoardDate,
            ApprovalDate = requestDto.ApprovalDate,
            DenialDate = requestDto.DenialDate,
            Policies = requestDto.Policies,
            RelatedProjects = requestDto.RelatedProjects,
            isNew = true,
            isActive = true,
            SendToBoard = false
        };

        context.Requests.Add(request);

       
        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetRequest), new { id = request.Id }, request);
        return BadRequest("Failed to create the request.");
        
    }

    [HttpPost("mandate")]
    public async Task<ActionResult<Request>> AddMandateToRequest(CreateMandateDto mandateDto, [FromQuery] int requestId)
    {
        var mandate = new Mandate
        {
            MandateBy = mandateDto.MandateBy,
            MandateTitle = mandateDto.MandateTitle,
            MandateDescription = mandateDto.MandateDescription,
            RequiredComplianceDate = mandateDto.RequiredComplianceDate,
            CodeRuleNums = mandateDto.CodeRuleNums
        };

        context.Mandates.Add(mandate);

        var request = await context.Requests.FindAsync(requestId);
        
        if (request == null) return NotFound("Request not found.");

        request.Mandate = mandate;

        var result = await context.SaveChangesAsync() > 0;

        

        if (result) return CreatedAtAction(nameof(GetRequest), new { id = mandate.Id }, mandate);
        return BadRequest("Failed to create the request.");
    }

    [HttpPost("impact")]
    public async Task<ActionResult<Request>> AddImpactToRequest(CreateImpactDto impactDto, [FromQuery] int requestId)
    {
        var impact = new Impact
        {
            InternalUserCount = impactDto.InternalUserCount,
            ExternalUserCount = impactDto.ExternalUserCount,
            NewAutomationExplain = impactDto.NewAutomationExplain,
            ExplainCostSavings = impactDto.ExplainCostSavings,
            ImpactedClassifications = impactDto.ImpactedClassifications,
            ImpactedExternalJobTypes = impactDto.ImpactedExternalJobTypes
        };

        context.Impacts.Add(impact);

        var request = await context.Requests.FindAsync(requestId);
        
        if (request == null) return NotFound("Request not found.");

        request.Impact = impact;

        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetRequest), new { id = impact.Id }, impact);
        return BadRequest("Failed to create the request.");
    }

    [HttpPost("scope")]
    public async Task<ActionResult<Request>> AddScopeToRequest(CreateScopeDto scopeDto, [FromQuery] int requestId)
    {
        var scope = new Scope
        {
            Objectives = scopeDto.Objectives,
            Requirements = scopeDto.Requirements,
            Resources = scopeDto.Resources,
        };

        context.Scopes.Add(scope);

        var request = await context.Requests.FindAsync(requestId);
        
        if (request == null) return NotFound("Request not found.");

        request.Scope = scope;

        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetRequest), new { id = scope.Id }, scope);
        return BadRequest("Failed to create the request.");
    }

    [HttpPut("{id}")]
    public string UpdateRequest(int id) 
    {
        return "Request Updated";
    }

    [HttpDelete("{id}")]
    public string DeleteRequest(int id) 
    {
        return "Request Deleted";
    }

}
