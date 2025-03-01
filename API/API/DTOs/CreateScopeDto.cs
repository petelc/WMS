using System;

namespace API.DTOs;

public class CreateScopeDto
{
    public required string Objectives { get; set; }
    public required string Requirements { get; set; }
    public required string Resources { get; set; }
}
