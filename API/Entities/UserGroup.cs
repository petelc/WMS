namespace API.Entities;

/// <summary>
/// Represents a user group in the system.
/// A user group is a collection of users that can be managed together.
/// User groups can be used to assign permissions, roles, or other attributes to a set of users.
/// This class is part of the API.Entities namespace and is used to define the structure of a user group entity.
/// </summary>
public class UserGroup
{
    public int Id { get; set; }
    public required string GroupName { get; set; }
    public string? GroupDescription { get; set; }

    // Navigation property for the join table
    public ICollection<EmployeeUserGroup> EmployeeUserGroups { get; set; } = new List<EmployeeUserGroup>();
}
