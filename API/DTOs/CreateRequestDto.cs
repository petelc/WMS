using API.Entities;

namespace API.DTOs;

public class CreateRequestDto
{
    public DateTime RequestedDate { get; set; }
    public required string RequestTitle { get; set; }
    public string? RequestedBy { get; set; }
    public string? Department { get; set; }
    public string? ExplainImpact { get; set; }
    public bool HasStakeHolderConferred { get; set; }
    public DateTime ProposedImpDate { get; set; }
    public DateTime BoardDate { get; set; }
    public DateTime ApprovalDate { get; set; }
    public DateTime DenialDate { get; set; }

    public ICollection<string>? Policies { get; set; }
    public ICollection<string>? RelatedProjects { get; set; }
    public required ICollection<string> MandateBy { get; set; }
    public required string MandateTitle { get; set; }
    public required string MandateDescription { get; set; }
    public DateTime RequiredComplianceDate { get; set; }
    public string? CodeRuleNums { get; set; }
    // impact fields
    public int InternalUserCount { get; set; }
    public int ExternalUserCount { get; set; }
    public required string NewAutomationExplain { get; set; }
    public string? ExplainCostSavings { get; set; }
    public ICollection<string>? ImpactedClassifications { get; set; }
    public ICollection<string>? ImpactedExternalJobTypes { get; set; }
    // scope fields
    public required string Objectives { get; set; }
    public required string Requirements { get; set; }
    public required string Resources { get; set; }

    public bool isNew { get; set; } = true;
    public bool isActive { get; set; } = true;
    public bool SendToBoard { get; set; } = false;
    
}
