using System;

namespace API.Entities;

public class ApprovalStatus
{
    public int Id { get; set; }
    public required string ApprovalStatusName { get; set; }
}
