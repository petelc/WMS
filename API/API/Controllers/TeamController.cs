using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TeamController(WMSContext context) : BaseApiController
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

    [HttpGet("requests/team-managers/{id}")]
    public async Task<ActionResult<List<RequestDto>>> GetRequestsByTeamManager(int id)
    {
        var requests = await context.Requests
            .Include(r => r.RequestType)
            .Include(r => r.Priority)
            .Include(r => r.RequestStatus)
            .Include(r => r.ApprovalStatus)
            .Include(r => r.Owner)
            .Include(r => r.Group)
            .Where(r => r.OwnerId == id || r.GroupId == id)
            .ToListAsync();

        return Ok(requests);
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
