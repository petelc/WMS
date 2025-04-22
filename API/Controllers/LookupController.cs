using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class LookupController(WMSContext context) : BaseApiController
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

    /// <summary>
    /// Get all priorities
    /// </summary>
    /// <returns>List of Priority Objects</returns>
    [HttpGet("priorities")]
    public async Task<ActionResult<List<Priority>>> GetPriorities()
    {
        var priorities = await context.Priorities.ToListAsync();
        return Ok(priorities);
    }

    /// <summary>
    /// Get all employees with UserGroupId = 1 (Team Managers)
    /// </summary>
    /// <returns>List of Employee Objects</returns>
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
            e.Region,
            e.Institution,
            e.Extension,
            e.Notes,
            e.ReportsTo,
            e.TeamId,
            TeamName = e.Team!.TeamName,
            UserGroupName = e.EmployeeUserGroups.FirstOrDefault(eug => eug.UserGroupId == 1)!.UserGroup.GroupName // Access GroupName
        })
        .ToListAsync();

        return Ok(employees);
        
    }

    [HttpGet("team-employees")]
    public async Task<ActionResult<List<EmployeeDto>>> GetTeamEmployees(int employeeId)
    {
        var team = await context.Employees
            .Include(e => e.Team)
            .Where(e => e.Id == employeeId)
            .Select(e => e.Team)
            .FirstOrDefaultAsync();

        if (team == null)
        {
            return NotFound("Team not found");
        }


        var employees = await context.Employees
            .Include(e => e.Team)
            .Include(e => e.EmployeeUserGroups)
            .ThenInclude(eug => eug.UserGroup) // Include UserGroup for access to GroupName
            .Where(e => e.TeamId == team.Id)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DisplayName = e.DisplayName,
                Team = e.Team,
                EmployeeUserGroups = e.EmployeeUserGroups.Select(eug => new EmployeeUserGroupDto
                {
                    UserGroupId = eug.UserGroupId,
                    GroupName = eug.UserGroup.GroupName
                }).ToList()
            })
            .ToListAsync();

        return Ok(employees);
    }

}
