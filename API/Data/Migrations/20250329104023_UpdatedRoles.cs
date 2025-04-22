using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9", null, "Team Manager", "TEAMMANAGER" });

            migrationBuilder.UpdateData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequestStatusName",
                value: "In-Progress");

            migrationBuilder.UpdateData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequestStatusName",
                value: "On-Hold");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequestStatusName",
                value: "Approved");

            migrationBuilder.UpdateData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequestStatusName",
                value: "Denied");
        }
    }
}
