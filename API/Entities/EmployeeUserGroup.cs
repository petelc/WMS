using System;

namespace API.Entities;

public class EmployeeUserGroup
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public int UserGroupId { get; set; }
    public UserGroup UserGroup { get; set; } = null!;
}
