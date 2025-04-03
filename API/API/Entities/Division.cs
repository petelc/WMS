namespace API.Entities;

public class Division
{
    public int DivisionId { get; set; }
    public required string DivisionName { get; set; }
    public string? DivisionDescription { get; set; }
    public ICollection<Section>? Sections { get; set; }
}
