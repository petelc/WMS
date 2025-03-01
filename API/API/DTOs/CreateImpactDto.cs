using System;

namespace API.DTOs;

public class CreateImpactDto
{
    public int InternalUserCount { get; set; }
    public int ExternalUserCount { get; set; }
    public required string NewAutomationExplain { get; set; }
    public string? ExplainCostSavings { get; set; }
    public ICollection<string>? ImpactedClassifications { get; set; }
    public ICollection<string>? ImpactedExternalJobTypes { get; set; }
}
