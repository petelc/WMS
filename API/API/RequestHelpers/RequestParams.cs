using System;

namespace API.RequestHelpers;

public class RequestParams : PaginationParams
{
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public bool? IsNew { get; set; }
    public bool? IsApproved { get; set; }
    public bool? IsBoard { get; set; } 
    public string? RequestType { get; set; }
    public string? Priority { get; set; }   
}
