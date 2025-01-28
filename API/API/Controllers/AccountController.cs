using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(SignInManager<User> signInManager) : BaseApiController
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
