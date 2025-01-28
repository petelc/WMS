using System;

namespace API.Entities;

public class Mandate
{
    public int Id { get; set; }
    public required string MandateBy { get; set; }
    public required string MandateTitle { get; set; }
    public required string MandateDescription { get; set; }
    public DateTime RequiredComplianceDate { get; set; }
    public ICollection<string>? CodeRuleNums { get; set; }
}
