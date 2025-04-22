using System;

namespace API.Entities;

public class Work
{
    public int Id { get; set; }
    public required string WorkName { get; set; }

    public required ICollection<WorkItem> WorkItems { get; set; }
    
}
