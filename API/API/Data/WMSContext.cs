using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace API.Data;

public class WMSContext(DbContextOptions<WMSContext> options) : IdentityDbContext<User>(options)
{
    public required DbSet<Request> Requests { get; set; }
    public required DbSet<RequestType> RequestTypes { get; set; }
    public required DbSet<RequestStatus> RequestStatuses { get; set; }
    public required DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
    public required DbSet<Priority> Priorities { get; set; }
    public required DbSet<Employee> Employees { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<WorkItem> WorkItems { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<Step> Steps { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /**
         * Create Roles for the users
         * Staff, 
         * Admin, 
         * BoardMember, 
         * ProjectManager, 
         * ChangeManager, 
         * ChangeCoordinator, 
         * Tech, 
         * Developer
         */

         builder.Entity<IdentityRole>().HasData(
             new IdentityRole { Id = "1", Name = "Staff", NormalizedName = "STAFF" },
             new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "ADMIN" },
             new IdentityRole { Id = "3", Name = "BoardMember", NormalizedName = "BOARDMEMBER" },
             new IdentityRole { Id = "4", Name = "ProjectManager", NormalizedName = "PROJECTMANAGER" },
             new IdentityRole { Id = "5", Name = "ChangeManager", NormalizedName = "CHANGEMANAGER" },
             new IdentityRole { Id = "6", Name = "ChangeCoordinator", NormalizedName = "CHANGECOORDINATOR" },
             new IdentityRole { Id = "7", Name = "Tech", NormalizedName = "TECH" },
             new IdentityRole { Id = "8", Name = "Developer", NormalizedName = "DEVELOPER" }
         );

         builder.Entity<RequestType>().HasData(
             new RequestType { Id = 1, RequestTypeName = "Change Request" },
             new RequestType { Id = 2, RequestTypeName = "Project Request" },
             new RequestType { Id = 3, RequestTypeName = "Work Request" }
         );

        builder.Entity<RequestStatus>().HasData(
            new RequestStatus { Id = 1, RequestStatusName = "New" },
            new RequestStatus { Id = 2, RequestStatusName = "Approved" },
            new RequestStatus { Id = 3, RequestStatusName = "Denied" },
            new RequestStatus { Id = 4, RequestStatusName = "Completed" }
        );

        builder.Entity<ApprovalStatus>().HasData(
            new ApprovalStatus { Id = 1, ApprovalStatusName = "Pending" },
            new ApprovalStatus { Id = 2, ApprovalStatusName = "Approved" },
            new ApprovalStatus { Id = 3, ApprovalStatusName = "Denied" }
        );

        builder.Entity<Priority>().HasData(
            new Priority { Id = 1, PriorityName = "Low" },
            new Priority { Id = 2, PriorityName = "Medium" },
            new Priority { Id = 3, PriorityName = "High" },
            new Priority { Id = 4, PriorityName = "Critical" }
        );

        
    }
}

