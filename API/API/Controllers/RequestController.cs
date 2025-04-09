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
            .Include(r => r.RequestType)
            .Include(r => r.Priority)
            .Include(r => r.RequestStatus)
            .Include(r => r.ApprovalStatus)
            .Include(r => r.Owner)
            .Include(r => r.Group)
            .Sort(requestParams.OrderBy)
            .Search(requestParams.SearchTerm)
            .Filter(requestParams.RequestType, requestParams.Priority)
            .Where(r => r.SendToBoard != true && r.OwnerId == null && r.GroupId == null)
            .AsQueryable();

        var pagedList = await PagedList<Request>.ToPagedList(query, 
            requestParams.PageNumber, requestParams.PageSize);

        Response.AddPaginationHeader(pagedList.Metadata);

        

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
        var requestType = await context.RequestTypes.Select(p => p.RequestTypeName).Distinct().ToListAsync();
        var priority = await context.Priorities.Select(p => p.PriorityName).Distinct().ToListAsync();

        return Ok(new { requestType, priority });
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
    public async Task<ActionResult> UpdateRequest(UpdateRequestDto updateRequestDto) 
    {
        var request = await context.Requests.FindAsync(updateRequestDto.Id);

        if (request == null) return NotFound();

        request.RequestedDate = updateRequestDto.RequestedDate;
        request.RequestTitle = updateRequestDto.RequestTitle;
        request.RequestedBy = updateRequestDto.RequestedBy;
        request.Department = updateRequestDto.Department;
        request.ExplainImpact = updateRequestDto.ExplainImpact;
        request.hasStakeHolderConferred = updateRequestDto.HasStakeHolderConferred;
        request.ProposedImpDate = updateRequestDto.ProposedImpDate;
        request.BoardDate = updateRequestDto.BoardDate;
        request.ApprovalDate = updateRequestDto.ApprovalDate;
        request.DenialDate = updateRequestDto.DenialDate;
        request.Policies = updateRequestDto.Policies;
        request.RelatedProjects = updateRequestDto.RelatedProjects;
        request.MandateBy = updateRequestDto.MandateBy;
        request.MandateTitle = updateRequestDto.MandateTitle;
        request.MandateDescription = updateRequestDto.MandateDescription;
        request.RequiredComplianceDate = updateRequestDto.RequiredComplianceDate;
        request.CodeRuleNums = updateRequestDto.CodeRuleNums;
        request.InternalUserCount = updateRequestDto.InternalUserCount;
        request.ExternalUserCount = updateRequestDto.ExternalUserCount;
        request.NewAutomationExplain = updateRequestDto.NewAutomationExplain;
        request.ExplainCostSavings = updateRequestDto.ExplainCostSavings;
        request.ImpactedClassifications = updateRequestDto.ImpactedClassifications;
        request.ImpactedExternalJobTypes = updateRequestDto.ImpactedExternalJobTypes;
        request.Objectives = updateRequestDto.Objectives;
        request.Requirements = updateRequestDto.Requirements;
        request.Resources = updateRequestDto.Resources;
        request.isNew = updateRequestDto.isNew;
        request.isActive = updateRequestDto.isActive;
        request.SendToBoard = updateRequestDto.SendToBoard;

        var result = await context.SaveChangesAsync() > 0; 

        if (result) return NoContent();
        
        return BadRequest("Failed to update the request.");
    }

    [HttpDelete("{id}")]
    public string DeleteRequest(int id) 
    {
        return "Request Deleted";
    }

}
