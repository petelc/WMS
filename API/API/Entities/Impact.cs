using System;

namespace API.Entities;

public class Impact
{
    public int Id { get; set; }
    public int InternalUserCount { get; set; }
    public int ExternalUserCount { get; set; }
    public required string NewAutomationExplain { get; set; }
    public string? ExplainCostSavings { get; set; }
    public ICollection<string>? ImpactedClassifications { get; set; }
    public ICollection<string>? ImpactedExternalJobTypes { get; set; }
}
