namespace API.Entities;

public class Section
{
    public int Id { get; set; }
    public required string SectionName { get; set; }
    public string? SectionDescription { get; set; }

    public int DivisionId { get; set; }
    public Division Division { get; set; } = null!;
    
    public ICollection<Team>? Teams { get; set; }
}
