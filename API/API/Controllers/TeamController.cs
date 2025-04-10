using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// TODO : Add authorization to the controller methods
// // TODO : Modify the GetRequestsByTeamManager method to use the userManager to get the user

public class TeamController(WMSContext context, SignInManager<User> signInManager) : BaseApiController
{
    [HttpGet("team-managers")]
    public async Task<ActionResult<List<EmployeeDto>>> GetTeamManagers()
    {
        var employees = await context.Employees
            .Include(e => e.EmployeeUserGroups)
            .ThenInclude(eug => eug.UserGroup) // Include UserGroup for access to GroupName
            .Where(e => e.EmployeeUserGroups.Any(eug => eug.UserGroupId == 1)) // Filter by UserGroupId
            .Select(e => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.DisplayName,
                EmployeeGroupName = e.EmployeeUserGroups.FirstOrDefault(eug => eug.UserGroupId == 1)!.UserGroup.GroupName
            })
            .ToListAsync();

        return Ok(employees);
    }

    [HttpGet("team-managers/{id}")]
    public async Task<ActionResult<EmployeeDto>> GetTeamManager(int id)
    {
        var employee = await context.Employees
            .Include(e => e.EmployeeUserGroups)
            .ThenInclude(eug => eug.UserGroup) // Include UserGroup for access to GroupName
            .Where(e => e.Id == id && e.EmployeeUserGroups.Any(eug => eug.UserGroupId == 1)) // Filter by UserGroupId
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DisplayName = e.DisplayName,
                EmployeeUserGroups = e.EmployeeUserGroups.Select(eug => new EmployeeUserGroupDto
                {
                    UserGroupId = eug.UserGroupId,
                    GroupName = eug.UserGroup.GroupName
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpGet("requests/team-managers")]
    public async Task<ActionResult<List<Request>>> GetRequestsByTeamManager([FromQuery] RequestParams requestParams)
    {
        var user = await signInManager.UserManager.GetUserAsync(User);

        if (user == null) return NotFound("User not found");
        
        var employee = await context.Employees
            .Include(eug => eug.EmployeeUserGroups)
            .Select(
                e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DisplayName = e.DisplayName,
                    EmployeeUserGroups = e.EmployeeUserGroups.Select(eug => new EmployeeUserGroupDto
                    {
                        UserGroupId = eug.UserGroupId,
                        GroupName = eug.UserGroup.GroupName
                    }).ToList()
                }
            ) // Include UserGroup for access to GroupName
            .FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
        
        if (employee == null) return NotFound("Employee not found");

        var requests = context.Requests
            .Include(r => r.RequestType)
            .Include(r => r.Priority)
            .Include(r => r.RequestStatus)
            .Include(r => r.ApprovalStatus)
            .Include(r => r.Owner)
            .Include(r => r.Group)
            .Where(r => r.OwnerId == employee.Id || r.GroupId == employee.Id)
            .AsQueryable();

            var pagedList = await PagedList<Request>.ToPagedList(requests,
            requestParams.PageNumber, requestParams.PageSize);

        Response.AddPaginationHeader(pagedList.Metadata);

        return pagedList;
    }

    [HttpPut("send-to-team-manager")]
    public async Task<ActionResult> SendToTeamManager(int id, int teamManagerId, int TeamId) 
    {
        var request = await context.Requests.FindAsync(id);

        if (request == null) return NotFound();
        // ? ownerId = 3 (Steve)
        // ? teamManagerId = 1 (Team Manager)
        //request.SendToBoard = true;
        request.OwnerId = teamManagerId;
        request.GroupId = TeamId;

        var result = await context.SaveChangesAsync() > 0; 

        if (result) return NoContent();
        
        return BadRequest("Failed to send the request to the team manager.");
    }

}
