using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class LookupController(WMSContext context, SignInManager<User> signInManager) : BaseApiController
{
    [HttpGet("request-types")]
    public async Task<ActionResult<List<RequestType>>> GetRequestTypes()
    {
        var requestTypes = await context.RequestTypes.ToListAsync();
        return Ok(requestTypes);
    }

    [HttpGet("request-statuses")]
    public async Task<ActionResult<List<RequestStatus>>> GetRequestStatuses()
    {
        var requestStatuses = await context.RequestStatuses.ToListAsync();
        return Ok(requestStatuses);
    }

    [HttpGet("approval-statuses")]
    public async Task<ActionResult<List<ApprovalStatus>>> GetApprovalStatuses()
    {
        var approvalStatuses = await context.ApprovalStatuses.ToListAsync();
        return Ok(approvalStatuses);
    }

    [HttpGet("priorities")]
    public async Task<ActionResult<List<Priority>>> GetPriorities()
    {
        var priorities = await context.Priorities.ToListAsync();
        return Ok(priorities);
    }

    [HttpGet("team-managers")]
    public async Task<ActionResult<List<User>>> GetTeamManagers()
    {
        var users = await signInManager.UserManager.GetUsersInRoleAsync("TeamManager");

        if (users == null || !users.Any()) return Unauthorized();

        var teamManagers = users.Select(user => new 
        {
            user.Id,
            user.Email,
            user.UserName,
        });

        return Ok(teamManagers.ToList());
        
    }

}
