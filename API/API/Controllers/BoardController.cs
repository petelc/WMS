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

    [HttpPut("{id}")]
    public async Task<ActionResult> AddToBoard(UpdateRequestDto updateRequestDto)
    {
        var request = await context.Requests.FindAsync(updateRequestDto.Id);

        return Ok();
    }

}
