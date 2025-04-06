using System;
using API.Entities;

namespace API.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public required string DisplayName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Region { get; set; }
    public string? Institution { get; set; }
    public string? Extension { get; set; }
    public string? Notes { get; set; }
    public int? ReportsTo { get; set; }

    
    public int? TeamId { get; set; }
    public Team? Team { get; set; }

    // Navigation property for the join table
    public int UserGroupId { get; set; }
    public ICollection<EmployeeUserGroupDto> EmployeeUserGroups { get; set; } = new List<EmployeeUserGroupDto>();
}
