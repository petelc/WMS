using System;
using Microsoft.AspNetCore.Identity;

namespace API.Entities;

public class User : IdentityUser
{
    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
