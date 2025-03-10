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
    public async Task<ActionResult<Request>> CreateRequest(CreateRequestDto requestDto)
    {
        
        var request = new Request
        {
            RequestedDate = DateTime.Now,
            RequestTitle = requestDto.RequestTitle,
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
            SendToBoard = false,
            MandateBy = requestDto.MandateBy,
            MandateTitle = requestDto.MandateTitle,
            MandateDescription = requestDto.MandateDescription,
            RequiredComplianceDate = requestDto.RequiredComplianceDate,
            CodeRuleNums = requestDto.CodeRuleNums,
            InternalUserCount = requestDto.InternalUserCount,
            ExternalUserCount = requestDto.ExternalUserCount,
            NewAutomationExplain = requestDto.NewAutomationExplain,
            ExplainCostSavings = requestDto.ExplainCostSavings,
            ImpactedClassifications = requestDto.ImpactedClassifications,
            ImpactedExternalJobTypes = requestDto.ImpactedExternalJobTypes,
            Objectives = requestDto.Objectives,
            Requirements = requestDto.Requirements,
            Resources = requestDto.Resources,
        };

        context.Requests.Add(request);

       
        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetRequest), new { id = request.Id }, request);
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
