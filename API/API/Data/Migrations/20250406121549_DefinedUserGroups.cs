using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DefinedUserGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserGroups_UserGroupId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserGroupId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Requests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Requests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeUserGroups",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUserGroups", x => new { x.EmployeeId, x.UserGroupId });
                    table.ForeignKey(
                        name: "FK_EmployeeUserGroups_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeUserGroups_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeUserGroups",
                columns: new[] { "EmployeeId", "UserGroupId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "GroupDescription", "GroupName" },
                values: new object[,]
                {
                    { 2, "Board Members", "BoardMember" },
                    { 3, "Project Managers", "ProjectManager" },
                    { 4, "Change Managers", "ChangeManager" },
                    { 5, "Change Coordinators", "ChangeCoordinator" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUserGroups",
                columns: new[] { "EmployeeId", "UserGroupId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GroupId",
                table: "Requests",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUserGroups_UserGroupId",
                table: "EmployeeUserGroups",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_OwnerId",
                table: "Requests",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_UserGroups_GroupId",
                table: "Requests",
                column: "GroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_OwnerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_UserGroups_GroupId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "EmployeeUserGroups");

            migrationBuilder.DropIndex(
                name: "IX_Requests_GroupId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests");

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserGroupId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserGroupId",
                table: "Employees",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserGroups_UserGroupId",
                table: "Employees",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
