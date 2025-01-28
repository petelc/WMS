using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Data;
using API.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// ? Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WMSContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

builder.Services.AddTransient<ExceptionMiddleware>();

// ? Add Identity
builder.Services.AddIdentityApiEndpoints<User>(opt => 
{
    opt.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WMSContext>();

var app = builder.Build();

// ? Configure the HTTP request pipeline.


app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(opt => {
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:3000");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("api").MapIdentityApi<User>();

DbInitializer.InitDb(app);

app.Run();
