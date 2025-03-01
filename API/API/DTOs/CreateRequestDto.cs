using System;

namespace API.DTOs;

public class CreateRequestDto
{
    public DateTime RequestedDate { get; set; }
    public required string RequestTitle { get; set; }
    public required string RequestDescription { get; set; }
    public string? RequestedBy { get; set; }
    public string? Department { get; set; }
    public string? ExplainImpact { get; set; }
    public bool HasStakeHolderConferred { get; set; }
    public DateTime ProposedImpDate { get; set; }
    public DateTime BoardDate { get; set; }
    public DateTime ApprovalDate { get; set; }
    public DateTime DenialDate { get; set; }

    // public int ApprovalStatusId { get; set; }
    // public int PriorityId { get; set; }
    // public int RequestTypeId { get; set; }
    // public int RequestStatusId { get; set; }
    // public int MandateId { get; set; }
    // public int ImpactId { get; set; }
    // public int ScopeId { get; set; }

    public ICollection<string>? Policies { get; set; }
    public ICollection<string>? RelatedProjects { get; set; }

    public bool isNew { get; set; } = true;
    public bool isActive { get; set; } = true;
    public bool SendToBoard { get; set; } = false;     
}
