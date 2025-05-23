/// <summary>
/// The entry point for the Work Management System (WMS) API application.
/// Configures services, middleware, and the HTTP request pipeline.
/// </summary>
/// <remarks>
/// This file sets up the application by:
/// - Adding services to the dependency injection container, such as controllers, database context, CORS, AutoMapper, and Identity.
/// - Configuring middleware for exception handling, CORS, authentication, and authorization.
/// - Mapping API endpoints, including Identity API endpoints.
/// - Initializing the database using the <see cref="DbInitializer.InitDb"/> method.
/// </remarks>
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Data;
using API.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// ? Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WMSContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ExceptionMiddleware>();
//builder.Services.AddSwaggerDocument();

// ? Add Identity
builder.Services.AddIdentityApiEndpoints<User>(opt => 
{
    opt.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WMSContext>();


builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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
