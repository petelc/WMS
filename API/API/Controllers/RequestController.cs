using System;
using API.Data;
using API.Entities;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RequestController(WMSContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Request>>> GetRequests([FromQuery] PaginationParams paginationParams)
    {
        var query = context.Requests.AsQueryable();

        var pagedList = await PagedList<Request>.ToPagedList(query, 
            paginationParams.PageNumber, paginationParams.PageSize);

        return pagedList;
    }
    

}
