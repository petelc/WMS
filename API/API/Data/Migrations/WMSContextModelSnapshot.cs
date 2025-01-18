﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(WMSContext))]
    partial class WMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("API.Entities.ApprovalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApprovalStatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ApprovalStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalStatusName = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            ApprovalStatusName = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            ApprovalStatusName = "Denied"
                        });
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Institution")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.Entities.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Priorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PriorityLevel = 0,
                            PriorityName = "Low"
                        },
                        new
                        {
                            Id = 2,
                            PriorityLevel = 0,
                            PriorityName = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            PriorityLevel = 0,
                            PriorityName = "High"
                        },
                        new
                        {
                            Id = 4,
                            PriorityLevel = 0,
                            PriorityName = "Critical"
                        });
                });

            modelBuilder.Entity("API.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ApprovalStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BoardDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DenialDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PriorityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SendToBoard")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isNew")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalStatusId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("RequestStatusId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("API.Entities.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestStatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RequestStatusName = "New"
                        },
                        new
                        {
                            Id = 2,
                            RequestStatusName = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            RequestStatusName = "Denied"
                        },
                        new
                        {
                            Id = 4,
                            RequestStatusName = "Completed"
                        });
                });

            modelBuilder.Entity("API.Entities.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RequestTypeName = "Change Request"
                        },
                        new
                        {
                            Id = 2,
                            RequestTypeName = "Project Request"
                        },
                        new
                        {
                            Id = 3,
                            RequestTypeName = "Work Request"
                        });
                });

            modelBuilder.Entity("API.Entities.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StepDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StepName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StepOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkTaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("API.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("API.Entities.WorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardIDNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriorityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PriorityId");

                    b.HasIndex("WorkId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("API.Entities.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("TEXT");

                    b.Property<double>("Progress")
                        .HasColumnType("REAL");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkItemId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isComplete")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Staff",
                            NormalizedName = "STAFF"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3",
                            Name = "BoardMember",
                            NormalizedName = "BOARDMEMBER"
                        },
                        new
                        {
                            Id = "4",
                            Name = "ProjectManager",
                            NormalizedName = "PROJECTMANAGER"
                        },
                        new
                        {
                            Id = "5",
                            Name = "ChangeManager",
                            NormalizedName = "CHANGEMANAGER"
                        },
                        new
                        {
                            Id = "6",
                            Name = "ChangeCoordinator",
                            NormalizedName = "CHANGECOORDINATOR"
                        },
                        new
                        {
                            Id = "7",
                            Name = "Tech",
                            NormalizedName = "TECH"
                        },
                        new
                        {
                            Id = "8",
                            Name = "Developer",
                            NormalizedName = "DEVELOPER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("API.Entities.Request", b =>
                {
                    b.HasOne("API.Entities.ApprovalStatus", "ApprovalStatus")
                        .WithMany()
                        .HasForeignKey("ApprovalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.RequestStatus", "RequestStatus")
                        .WithMany()
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovalStatus");

                    b.Navigation("Priority");

                    b.Navigation("RequestStatus");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("API.Entities.Step", b =>
                {
                    b.HasOne("API.Entities.WorkTask", null)
                        .WithMany("Steps")
                        .HasForeignKey("WorkTaskId");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.HasOne("API.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Entities.WorkItem", b =>
                {
                    b.HasOne("API.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Work", null)
                        .WithMany("WorkItems")
                        .HasForeignKey("WorkId");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("API.Entities.WorkTask", b =>
                {
                    b.HasOne("API.Entities.WorkItem", null)
                        .WithMany("WorkTasks")
                        .HasForeignKey("WorkItemId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Work", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("API.Entities.WorkItem", b =>
                {
                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("API.Entities.WorkTask", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
