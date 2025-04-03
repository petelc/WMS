using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Team
{
    public int TeamId { get; set; }
    public required string TeamName { get; set; }
    public string? TeamDescription { get; set; }
    public int SectionId { get; set; }
    public required Section Section { get; set; }
}
