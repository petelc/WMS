using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BoardController(WMSContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Request>>> GetBoardRequests([FromQuery] RequestParams requestParams)
    {
        var query = context.Requests
            .Include(r => r.RequestType)
            .Include(r => r.Priority)
            .Include(r => r.RequestStatus)
            .Include(r => r.ApprovalStatus)
            .Sort(requestParams.OrderBy)
            .Search(requestParams.SearchTerm)
            .Filter(requestParams.RequestType, requestParams.Priority)
            .Where(r => r.SendToBoard == true)
            .AsQueryable();

        var pagedList = await PagedList<Request>.ToPagedList(query,
            requestParams.PageNumber, requestParams.PageSize);

        Response.AddPaginationHeader(pagedList.Metadata);

        return pagedList;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBoardRequest(UpdateRequestDto updateRequestDto)
    {
        var request = await context.Requests.FindAsync(updateRequestDto.Id);

        if (request == null)
            return NotFound();

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

        if (result)
            return NoContent();

        return BadRequest("Failed to update request");
    }
    
    

}
