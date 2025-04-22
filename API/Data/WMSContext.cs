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

    public DbSet<Team> Teams { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<EmployeeUserGroup> EmployeeUserGroups { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        

        
        // Configure Many-to-Many Relationship
        builder.Entity<EmployeeUserGroup>()
            .HasKey(eug => new { eug.EmployeeId, eug.UserGroupId }); // Composite primary key

        builder.Entity<EmployeeUserGroup>()
            .HasOne(eug => eug.Employee)
            .WithMany(e => e.EmployeeUserGroups)
            .HasForeignKey(eug => eug.EmployeeId);

        builder.Entity<EmployeeUserGroup>()
            .HasOne(eug => eug.UserGroup)
            .WithMany(ug => ug.EmployeeUserGroups)
            .HasForeignKey(eug => eug.UserGroupId);
        
        builder.Entity<UserGroup>().HasData(
             new UserGroup { Id = 1, GroupName = "TeamManager", GroupDescription = "Team Managers"},
             new UserGroup { Id = 2, GroupName = "BoardMember", GroupDescription = "Board Members"},
             new UserGroup { Id = 3, GroupName = "ProjectManager", GroupDescription = "Project Managers"},
             new UserGroup { Id = 4, GroupName = "ChangeManager", GroupDescription = "Change Managers"},
             new UserGroup { Id = 5, GroupName = "ChangeCoordinator", GroupDescription = "Change Coordinators"}
             
         );

        builder.Entity<Employee>().HasData(
            new Employee { Id = 1, FirstName = "Logan", LastName = "Bently", DisplayName = "Logan Bently", Region = "Region 1", Institution = "Institution 1", Extension = "1234", Notes = "Notes 1", ReportsTo = 2, TeamId = 2 },
            new Employee { Id = 2, FirstName = "Bob", LastName = "Newhart", DisplayName = "Bob Newhart", Region = "Region 2", Institution = "Institution 2", Extension = "5678", Notes = "Notes 2", ReportsTo = 6, TeamId = 3 },
            new Employee { Id = 3, FirstName = "Steve", LastName = "Marshal", DisplayName = "Steve Marshal", Region = "Region 3", Institution = "Institution 3", Extension = "9101", Notes = "Notes 3", ReportsTo = 5, TeamId = 2},
            new Employee { Id = 4, FirstName = "Michelle", LastName = "Rodriguez", DisplayName = "Michelle Rodriguez", Region = "Region 1", Institution = "Institution 1", Extension = "1235", Notes = "Notes 1", ReportsTo = 6, TeamId = 4 },
            new Employee { Id = 5, FirstName = "Kathy", LastName = "Renalds", DisplayName = "Kathy Renalds", Region = "Region 2", Institution = "Institution 2", Extension = "5677", Notes = "Notes 2", ReportsTo = 6, TeamId = 4 },
            new Employee { Id = 6, FirstName = "Dave", LastName = "Pennyworth", DisplayName = "Dave Pennyworth", Region = "Region 3", Institution = "Institution 3", Extension = "9102", Notes = "Notes 3" },
            new Employee { Id = 7, FirstName = "Lucy", LastName = "Lawless", DisplayName = "Lucy Lawless", Region = "Region 1", Institution = "Institution 1", Extension = "1236", Notes = "Notes 1", ReportsTo = 3, TeamId = 1 },
            new Employee { Id = 8, FirstName = "Pete", LastName = "Rose", DisplayName = "Pete Rose", Region = "Region 2", Institution = "Institution 2", Extension = "5679", Notes = "Notes 2", ReportsTo = 2, TeamId = 4 },
            new Employee { Id = 9, FirstName = "Ben", LastName = "Boss", DisplayName = "Ben Boss", Region = "Region 3", Institution = "Institution 3", Extension = "9103", Notes = "Notes 3", ReportsTo = 5, TeamId = 1 }
        );

        // Seed Data for the Join Table
        builder.Entity<EmployeeUserGroup>().HasData(
            new EmployeeUserGroup { EmployeeId = 2, UserGroupId = 1 }, // Bob is a Team Manager
            new EmployeeUserGroup { EmployeeId = 3, UserGroupId = 2 }, // Steve is a Board Member
            new EmployeeUserGroup { EmployeeId = 3, UserGroupId = 1 }, // Steve is also a Team Manager
            new EmployeeUserGroup { EmployeeId = 4, UserGroupId = 3 }, // Michelle is a Project Manager
            new EmployeeUserGroup { EmployeeId = 5, UserGroupId = 4 }, // Kathy is a Change Manager
            new EmployeeUserGroup { EmployeeId = 5, UserGroupId = 1 }, // Kathy is also a Team Manager
            new EmployeeUserGroup { EmployeeId = 6, UserGroupId = 5 }, // Dave is a Change Coordinator
            new EmployeeUserGroup { EmployeeId = 9, UserGroupId = 1 }  // Ben is a Team Manager
        );



        /**
         * Create Roles for the users
         * Staff, 
         
         * Admin, 
         * BoardMember, 
         * ProjectManager, 
         * ChangeManager, 
         * ChangeCoordinator, 
         * Team Manager,
         * Staff,
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
             new IdentityRole { Id = "8", Name = "Developer", NormalizedName = "DEVELOPER" },
             new IdentityRole { Id = "9", Name = "Team Manager", NormalizedName = "TEAMMANAGER" }
         );

         

         builder.Entity<RequestType>().HasData(
             new RequestType { Id = 1, RequestTypeName = "Change Request" },
             new RequestType { Id = 2, RequestTypeName = "Project Request" },
             new RequestType { Id = 3, RequestTypeName = "Work Request" }
         );

        builder.Entity<RequestStatus>().HasData(
            new RequestStatus { Id = 1, RequestStatusName = "New" },
            new RequestStatus { Id = 2, RequestStatusName = "In-Progress" },
            new RequestStatus { Id = 3, RequestStatusName = "On-Hold" },
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

        builder.Entity<Division>().HasData(
            new Division { Id = 1, DivisionName = "BITS", DivisionDescription = "Business Information Technology Services" },
            new Division { Id = 2, DivisionName = "OOP", DivisionDescription = "Office of Prisons" },
            new Division { Id = 3, DivisionName = "EDU", DivisionDescription= "Education" },
            new Division { Id = 4, DivisionName = "MED", DivisionDescription = "Medical" },
            new Division { Id = 5, DivisionName = "MH", DivisionDescription = "Mental Health" }
        );

        builder.Entity<Section>().HasData(
            new Section { Id = 1, SectionName = "Infrastructure", SectionDescription = "Infrastructure and Operations", DivisionId = 1 },
            new Section { Id = 2, SectionName = "Networking", SectionDescription = "Networking and Communications", DivisionId = 1 },
            new Section { Id = 3, SectionName = "Security", SectionDescription = "Security Operations", DivisionId = 1 },
            new Section { Id = 4, SectionName = "AppDev", SectionDescription = "Application Development", DivisionId = 1 }
        );

        builder.Entity<Team>().HasData(
            new Team { Id = 1, TeamName = "Maintenance Team", TeamDescription = "Maintenance", SectionId = 4 },
            new Team { Id = 2, TeamName = "Cloud Team", TeamDescription = "Cloud Services", SectionId = 4 },
            new Team { Id = 3, TeamName = "ORAS Team", TeamDescription = "ORAS", SectionId = 4 },
            new Team { Id = 4, TeamName = "Forms Team", TeamDescription = "Forms", SectionId = 4 }
        );
    }
}

