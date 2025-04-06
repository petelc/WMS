using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Sections",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Divisions",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "DivisionDescription", "DivisionName" },
                values: new object[,]
                {
                    { 1, "Business Information Technology Services", "BITS" },
                    { 2, "Office of Prisons", "OOP" },
                    { 3, "Education", "EDU" },
                    { 4, "Medical", "MED" },
                    { 5, "Mental Health", "MH" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DisplayName", "Extension", "FirstName", "Institution", "LastName", "Notes", "Region", "ReportsTo" },
                values: new object[,]
                {
                    { 1, "Logan Bently", "1234", "Logan", "Institution 1", "Bently", "Notes 1", "Region 1", null },
                    { 2, "Bob Newhart", "5678", "Bob", "Institution 2", "Newhart", "Notes 2", "Region 2", null },
                    { 3, "Steve Marshal", "9101", "Steve", "Institution 3", "Marshal", "Notes 3", "Region 3", null },
                    { 4, "Michelle Rodriguez", "1235", "Michelle", "Institution 1", "Rodriguez", "Notes 1", "Region 1", null },
                    { 5, "Kathy Renalds", "5677", "Kathy", "Institution 2", "Renalds", "Notes 2", "Region 2", null },
                    { 6, "Dave Pennyworth", "9102", "Dave", "Institution 3", "Pennyworth", "Notes 3", "Region 3", null },
                    { 7, "Lucy Lawless", "1236", "Lucy", "Institution 1", "Lawless", "Notes 1", "Region 1", null },
                    { 8, "Pete Rose", "5679", "Pete", "Institution 2", "Rose", "Notes 2", "Region 2", null },
                    { 9, "Ben Boss", "9103", "Ben", "Institution 3", "Boss", "Notes 3", "Region 3", null }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "DivisionId", "SectionDescription", "SectionName" },
                values: new object[,]
                {
                    { 1, 1, "Infrastructure and Operations", "Infrastructure" },
                    { 2, 1, "Networking and Communications", "Networking" },
                    { 3, 1, "Security Operations", "Security" },
                    { 4, 1, "Application Development", "AppDev" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "EmployeeId", "SectionId", "TeamDescription", "TeamName" },
                values: new object[,]
                {
                    { 1, 9, 4, "Maintenance", "Maintenance Team" },
                    { 2, 3, 4, "Cloud Services", "Cloud Team" },
                    { 3, 2, 4, "ORAS", "ORAS Team" },
                    { 4, 5, 4, "Forms", "Forms Team" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sections",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Divisions",
                newName: "DivisionId");
        }
    }
}
