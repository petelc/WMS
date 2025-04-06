using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Team
{
    public int Id { get; set; }
    public required string TeamName { get; set; }
    public string? TeamDescription { get; set; }

    // ? relationships
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;

    // public int? EmployeeId { get; set; }
    // public Employee? Employee { get; set; }

    
    //public ICollection<Employee> Employees { get; set; } = [];
}
