using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingEmployeeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTeam");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EmployeeTeam",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTeam", x => new { x.EmployeesId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_EmployeeTeam_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTeam_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTeam_TeamsTeamId",
                table: "EmployeeTeam",
                column: "TeamsTeamId");
        }
    }
}
