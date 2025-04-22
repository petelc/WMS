using System;

namespace API.Entities;

public class Priority
{
    public int Id { get; set; }
    public required string PriorityName { get; set; }
    public int PriorityLevel { get; set; }
}
