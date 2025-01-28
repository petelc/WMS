using System;

namespace API.Entities;

public class Scope
{
    public int Id { get; set; }
    public required string Objectives { get; set; }
    public required string Requirements { get; set; }
    public required string Resources { get; set; }
}
