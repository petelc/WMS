using System;
using System.Net.Http.Headers;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<WMSContext>()
            ?? throw new InvalidOperationException("Could not get WMSContext service.");

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>()
            ?? throw new InvalidOperationException("Could not get UserManager<User> service.");

        SeedData(context, userManager);
    }

    private static async void SeedData(WMSContext context, UserManager<User> userManager)
    {
        context.Database.Migrate();

        if (!userManager.Users.Any())
        {
            //? Create a new user for each role and assign the role to the user
            var user = new User
            {
                UserName = "logan@test.com",
                Email = "logan@test.com"
            };

            await userManager.CreateAsync(user, "P@ssw0rd");
            await userManager.AddToRoleAsync(user, "Staff");

            var admin = new User
            {
                UserName = "bob@test.com",
                Email = "bob@test.com"
            };

            await userManager.CreateAsync(admin, "P@ssw0rd");
            await userManager.AddToRoleAsync(admin, "Admin");

            var board = new User
            {
                UserName = "steve@test.com",
                Email = "steve@test.com"
            };

            await userManager.CreateAsync(board, "P@ssw0rd");
            await userManager.AddToRoleAsync(board, "BoardMember");

            var project = new User
            {
                UserName = "michelle@test.com",
                Email = "michelle@test.com"
            };

            await userManager.CreateAsync(project, "P@ssw0rd");
            await userManager.AddToRoleAsync(project, "ProjectManager");

            var change = new User
            {
                UserName = "kathy@test.com",
                Email = "kathy@test.com"
            };

            await userManager.CreateAsync(change, "P@ssw0rd");
            await userManager.AddToRoleAsync(change, "ChangeManager");

            var coordinator = new User
            {
                UserName = "dave@test.com",
                Email = "dave@test.com"
            };

            await userManager.CreateAsync(coordinator, "P@ssw0rd");
            await userManager.AddToRoleAsync(coordinator, "ChangeCoordinator");

            var tech = new User
            {
                UserName = "lucy@test.com",
                Email = "lucy@test.com"
            };

            await userManager.CreateAsync(tech, "P@ssw0rd");
            await userManager.AddToRoleAsync(tech, "Tech");

            var developer = new User
            {
                UserName = "pete@test.com",
                Email = "pete@test.com"
            };

            await userManager.CreateAsync(developer, "P@ssw0rd");
            await userManager.AddToRoleAsync(developer, "Developer");
        }

        if (context.Requests.Any()) return;

        var requests = new List<Request>
        {
            new() {
                Id = 1,
                RequestedDate = DateTime.Now,
                RequestTitle = "Request 1",
                RequestDescription = "Request 1 Description",
                RequestedBy = "Logan", // requested by
                Department = "OOP", //department
                ExplainImpact = "Impacts explanation", // explain impact
                hasStakeHolderConferred = true, // has stake holders conferred
                ProposedImpDate = DateTime.Parse("2025-05-24"), // proposed implement date
                BoardDate = DateTime.Parse("1970-01-01"),
                ApprovalDate = DateTime.Parse("1970-01-01"),
                DenialDate = DateTime.Parse("1970-01-01"),
                Policies = new List<string> {"None"}, // policies
                RelatedProjects = new List<string> {"None"}, // related projects[]
                isNew = true,
                isActive = true,
                SendToBoard = false,
                ApprovalStatusId = 1,
                PriorityId = 1,
                RequestTypeId = 1,
                RequestStatusId = 1,
                MandateId = 1,
                ImpactId = 1,
                ScopeId = 1
            },
            new() {
                Id = 2,
                RequestedDate = DateTime.Parse("2025-01-04"),
                RequestTitle = "Request 2",
                RequestDescription = "Request 2 Description",
                RequestedBy = "Heather Thomas", // requested by
                Department = "MH", //department
                ExplainImpact = "Impacts explanation", // explain impact
                hasStakeHolderConferred = true, // has stake holders conferred
                ProposedImpDate = DateTime.Parse("2025-05-24"), // proposed implement date
                isNew = true,
                isActive = true,
                SendToBoard = false,
                BoardDate = DateTime.Parse("1970-01-01"),
                ApprovalDate = DateTime.Parse("1970-01-01"),
                DenialDate = DateTime.Parse("1970-01-01"),
                Policies = new List<string> {"None"}, // policies
                RelatedProjects = new List<string> {"None"}, // related projects[]
                ApprovalStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 2,
                RequestStatusId = 1,
                MandateId = 2,
                ImpactId = 2,
                ScopeId = 2
            },
            new() {
                Id = 3,
                RequestedDate = DateTime.Parse("2025-01-12"),
                RequestTitle = "Request 3",
                RequestDescription = "Request 3 Description",
                RequestedBy = "John P Tanner", // requested by
                Department = "AOCI", //department
                ExplainImpact = "Impacts explanation", // explain impact
                hasStakeHolderConferred = true, // has stake holders conferred
                ProposedImpDate = DateTime.Parse("2025-05-24"), // proposed implement date
                isNew = true,
                isActive = true,
                SendToBoard = false,
                BoardDate = DateTime.Parse("1970-01-01"),
                ApprovalDate = DateTime.Parse("1970-01-01"),
                DenialDate = DateTime.Parse("1970-01-01"),
                Policies = new List<string> {"None"}, // policies
                RelatedProjects = new List<string> {"None"}, // related projects[]
                ApprovalStatusId = 1,
                PriorityId = 3,
                RequestTypeId = 3,
                RequestStatusId = 1,
                MandateId = 1,
                ImpactId = 1,
                ScopeId = 1
            },
            new() {
                Id = 4,
                RequestedDate = DateTime.Parse("2025-01-19"),
                RequestTitle = "Request 4",
                RequestDescription = "Request 4 Description",
                RequestedBy = "Stacy Cooper", // requested by
                Department = "EDU", //department
                ExplainImpact = "Impacts explanation", // explain impact
                hasStakeHolderConferred = true, // has stake holders conferred
                ProposedImpDate = DateTime.Parse("2025-05-24"), // proposed implement date
                isNew = true,
                isActive = true,
                SendToBoard = false,
                BoardDate = DateTime.Parse("1970-01-01"),
                ApprovalDate = DateTime.Parse("1970-01-01"),
                DenialDate = DateTime.Parse("1970-01-01"),
                Policies = new List<string> {"None"}, // policies
                RelatedProjects = new List<string> {"None"}, // related projects[]
                ApprovalStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 3,
                RequestStatusId = 1,
                MandateId = 2,
                ImpactId = 2,
                ScopeId = 2
            }
        };

        context.Requests.AddRange(requests);

        var mandates = new List<Mandate>
        {
            new() { 
                Id = 1, 
                MandateBy = "MandateBy 1", 
                MandateTitle = "MandateTitle 1", 
                MandateDescription = "MandateDescription 1", RequiredComplianceDate = DateTime.Parse("2025-01-01") 
            },
            new() { 
                Id = 2, 
                MandateBy = "MandateBy 2",
                MandateTitle = "MandateTitle 2", 
                MandateDescription = "MandateDescription 2", RequiredComplianceDate = DateTime.Parse("2025-01-02") 
            }
        };

        context.Mandates.AddRange(mandates);

        var impacts = new List<Impact>
        {
            new() { 
                Id = 1, 
                InternalUserCount = 100, 
                ExternalUserCount = 200, NewAutomationExplain = "NewAutomationExplain 1" 
            },
            new() { 
                Id = 2, 
                InternalUserCount = 150, 
                ExternalUserCount = 250, 
                NewAutomationExplain = "NewAutomationExplain 2" 
            }
        };

        context.Impacts.AddRange(impacts);

        var scopes = new List<Scope>
        {
            new() { 
                Id = 1, 
                Objectives = "Objectives 1", 
                Requirements = "Requirements 1", 
                Resources = "Resources 1" 
            },
            new() { 
                Id = 2, 
                Objectives = "Objectives 2", 
                Requirements = "Requirements 2", 
                Resources = "Resources 2" 
            }
        };

        context.Scopes.AddRange(scopes);

        context.SaveChanges();
    }
}
