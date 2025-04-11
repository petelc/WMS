using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(SignInManager<User> signInManager, UserManager<User> userManager, WMSContext context) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.Email,
            Email = registerDto.Email
        };

        var result = await signInManager.UserManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        await signInManager.UserManager.AddToRoleAsync(user, "Staff");

        return Ok();
    }

    [HttpGet("user-info")]
    public async Task<ActionResult> GetUserInfo()
    {
        //if (User.Identity?.IsAuthenticated == false) return NoContent();

        var user = await signInManager.UserManager.GetUserAsync(User);

        if (user == null) return Unauthorized();

        var roles = await signInManager.UserManager.GetRolesAsync(user);

        return Ok(new 
        {
            user.Email,
            user.UserName,
            Roles = roles
        });
    }

    [HttpPost("logout")]    
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }

    [Authorize]
    [HttpPost("employee")]
    public async Task<ActionResult<Employee>> CreateOrUpdateEmployee(Employee employee)
    {
        var user = await signInManager.UserManager.Users
            .Include(u => u.Employee)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity!.Name);

        if (user == null) return Unauthorized();

        user.Employee = employee;

        var result = await signInManager.UserManager.UpdateAsync(user);

        if (!result.Succeeded) return BadRequest("Problem updating user's profile");

        return Ok(user.Employee);
    }

    [HttpGet("all-employees")]
    public async Task<ActionResult<List<Employee>>> GetAllEmployees()
    {
        var employees = await userManager.Users
            .Include(u => u.Employee)
            .ThenInclude(u => u!.Team)
            .Select(u => u.Employee)
            .Where(u => u != null)
            .ToListAsync();
        if (employees == null) return NoContent();

        if (employees.Count == 0) return NoContent();

        return Ok(employees);
    }

    [HttpGet("employees-usergroups")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployeesUserGroups()
    {
        var employees = await context.EmployeeUserGroups
            .Include(e => e.Employee)
            .Select(e => new 
            {
                e.Employee.Id,
                e.Employee.FirstName,
                e.Employee.LastName,
                e.Employee.DisplayName,
                e.Employee.Region,
                e.Employee.Institution,
                e.Employee.Extension,
                e.Employee.Notes,
                e.Employee.ReportsTo,
                e.Employee.TeamId,
                EmployeeUserGroups = e.Employee.EmployeeUserGroups.Select(u => new {
                    u.Employee.Id,
                    u.Employee.FirstName,
                    u.Employee.LastName,
                    u.UserGroup.GroupName,
                }).ToList()
            })
            .ToListAsync();
        
        if (employees == null || employees.Count == 0) return NoContent();
        

        return Ok(employees);
    }


    [HttpGet("employees-teams")]
    public async Task<ActionResult<List<Employee>>> GetEmployeesTeams()
    {
        var employees = await context.Employees
            .Include(e => e.Team)
            .ToListAsync();
        
        if (employees == null) return NoContent();

        if (employees.Count == 0) return NoContent();

        return Ok(employees);
    }

    [Authorize]
    [HttpGet("employee")]
    public async Task<ActionResult<Employee>> GetSavedEmployee()
    {
        var employee = await signInManager.UserManager.Users
            .Where(u => u.UserName == User.Identity!.Name)
            .Select(u => u.Employee)
            .FirstOrDefaultAsync();

        if (employee == null) return NoContent();

        return employee;
    }
}


// 1	Logan Bently
// 2	Bob Newhart
// 3	Steve Marshal
// 4	Michelle Rodrigez
// 5	Kathy Renalds
// 6	Dave Pennyworth
// 7	Lucy Lawless
// 8	Pete Rose
// 9	Ben Boss