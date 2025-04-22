namespace API.Entities;

public class Step
{
    public int Id { get; set; }
    public required string StepName { get; set; }
    public required string StepDescription { get; set; }
    public int StepOrder { get; set; }
}
