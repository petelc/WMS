using System;
using API.Data;
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
    public string AddRequest() 
    {
        return "Request Added";
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
