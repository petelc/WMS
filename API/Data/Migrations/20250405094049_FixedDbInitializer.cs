using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedDbInitializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "TeamId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReportsTo", "TeamId" },
                values: new object[] { 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReportsTo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmployeeId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
