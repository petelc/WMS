using System;

namespace API.Entities;

public class Request
{
    // request fields
    public int Id  { get; set; }
    public DateTime RequestedDate { get; set; }
    public required string RequestTitle { get; set; }
    public string? RequestedBy { get; set; }
    public string? Department { get; set; }
    public string? ExplainImpact { get; set; }
    public bool hasStakeHolderConferred { get; set; }
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
    
    public int InternalUserCount { get; set; }
    public int ExternalUserCount { get; set; }
    public required string NewAutomationExplain { get; set; }
    public string? ExplainCostSavings { get; set; }
    public ICollection<string>? ImpactedClassifications { get; set; }
    public ICollection<string>? ImpactedExternalJobTypes { get; set; }
    
    public required string Objectives { get; set; }
    public required string Requirements { get; set; }
    public required string Resources { get; set; }
      
    public bool isNew { get; set; }
    public bool isActive { get; set; }
    public bool SendToBoard { get; set; }

    public int? ApprovalStatusId { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }
    public int? PriorityId { get; set; }
    public Priority? Priority { get; set; }
    public int? RequestTypeId { get; set; }
    public RequestType? RequestType { get; set; }
    public int? RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
}
