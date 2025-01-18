using System;

namespace API.Entities;

public class Request
{
    public int Id  { get; set; }
    public DateTime RequestedDate { get; set; }
    public required string RequestTitle { get; set; }
    public required string RequestDescription { get; set; }
    public bool isNew { get; set; }
    public bool isActive { get; set; }
    public bool SendToBoard { get; set; }
    public DateTime BoardDate { get; set; }
    public DateTime ApprovalDate { get; set; }
    public DateTime DenialDate { get; set; }

    public int ApprovalStatusId { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }
    public int PriorityId { get; set; }
    public Priority? Priority { get; set; }
    public int RequestTypeId { get; set; }
    public RequestType? RequestType { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
}
