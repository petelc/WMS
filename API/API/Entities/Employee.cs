using System;
using System.ComponentModel.Design.Serialization;

namespace API.Entities;

public class Employee
{
    public int Id { get; set; }
    public required string DisplayName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Region { get; set; }
    public string? Institution { get; set; }
    public string? Extension { get; set; }
    public string? Notes { get; set; }
    public int? ReportsTo { get; set; }
    
}
