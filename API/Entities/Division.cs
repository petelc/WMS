namespace API.Entities;

public class Division
{
    public int Id { get; set; }
    public required string DivisionName { get; set; }
    public string? DivisionDescription { get; set; }
    public ICollection<Section> Sections { get; set; } = new List<Section>();
}
