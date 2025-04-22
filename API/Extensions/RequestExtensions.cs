using System;
using API.Entities;

namespace API.Extensions;

public static class RequestExtensions
{
    public static IQueryable<Request> Sort(this IQueryable<Request> query, string? orderBy)
    {
        return orderBy switch
        {
            "newest" => query.OrderByDescending(x => x.RequestedDate),
            "oldest" => query.OrderBy(x => x.RequestedDate),
            "type" => query.OrderByDescending(x => x.RequestType),
            "priority" => query.OrderByDescending(x => x.Priority),
            _ => query.OrderByDescending(x => x.RequestedDate)
        };
    }

    public static IQueryable<Request> Search(this IQueryable<Request> query, string? searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return query;

        var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

        return query.Where(x => x.RequestTitle.ToLower().Contains(lowerCaseSearchTerm));
    }

    public static IQueryable<Request> Filter(this IQueryable<Request> query, string? requestTypes, string? priorities)
    {
        var typesList = new List<string>();
        var prioritiesList = new List<string>();

        if (!string.IsNullOrEmpty(requestTypes))
        {
            typesList.AddRange([.. requestTypes.ToLower().Split(',')]);
        }

        if (!string.IsNullOrEmpty(priorities))
        {
            prioritiesList.AddRange([.. priorities.ToLower().Split(',')]);
        }

        query = query.Where(x => typesList.Count == 0 || typesList.Contains(x.RequestType!.RequestTypeName.ToLower()));
        query = query.Where(x => prioritiesList.Count == 0 || prioritiesList.Contains(x.Priority!.PriorityName.ToLower()));

        return query;
    }
    
}
