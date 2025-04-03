namespace API.Entities;

public class Section
{
    public int SectionId { get; set; }
    public required string SectionName { get; set; }
    public string? SectionDescription { get; set; }
    public ICollection<Team>? Teams { get; set; }
}
