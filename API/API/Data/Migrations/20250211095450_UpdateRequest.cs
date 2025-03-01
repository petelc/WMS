using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ApprovalStatuses_ApprovalStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Impacts_ImpactId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Mandates_MandateId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Scopes_ScopeId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "ScopeId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RequestStatusId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MandateId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ImpactId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "Requests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ApprovalStatuses_ApprovalStatusId",
                table: "Requests",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Impacts_ImpactId",
                table: "Requests",
                column: "ImpactId",
                principalTable: "Impacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Mandates_MandateId",
                table: "Requests",
                column: "MandateId",
                principalTable: "Mandates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Scopes_ScopeId",
                table: "Requests",
                column: "ScopeId",
                principalTable: "Scopes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ApprovalStatuses_ApprovalStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Impacts_ImpactId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Mandates_MandateId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Scopes_ScopeId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "ScopeId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestStatusId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MandateId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImpactId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ApprovalStatuses_ApprovalStatusId",
                table: "Requests",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Impacts_ImpactId",
                table: "Requests",
                column: "ImpactId",
                principalTable: "Impacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Mandates_MandateId",
                table: "Requests",
                column: "MandateId",
                principalTable: "Mandates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Priorities_PriorityId",
                table: "Requests",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Scopes_ScopeId",
                table: "Requests",
                column: "ScopeId",
                principalTable: "Scopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
