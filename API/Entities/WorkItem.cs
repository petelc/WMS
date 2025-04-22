using System;

namespace API.Entities;

public class WorkItem
{
    public int Id { get; set; }
    public required string CardIDNum { get; set; }
    public required string Header { get; set; }
    public required string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PriorityId { get; set; }
    public Priority? Priority { get; set; }

    public required ICollection<WorkTask> WorkTasks { get; set; }
}
