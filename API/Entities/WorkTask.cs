using System;

namespace API.Entities;

public class WorkTask
{
    public int Id { get; set; }
    public required string TaskName { get; set; }
    public required string TaskDescription { get; set; }

    public bool isComplete { get; set; }
    public DateTime? DateCompleted { get; set; }
    public double Progress { get; set; }
    public string? Comments { get; set; }
    public required ICollection<Step> Steps { get; set; }

}

/*
    A request is a project or a change request.
    A request generates a piece of work. A request can have multiple pieces of work.
    Each piece of work has multiple workitems.
    Each workitem has multiple tasks. (think a todo list for each workitem)
    Each task has multiple steps (think a checklist for each task)
    Each task allows for comments  (this of resolution notes for each task)

*/
