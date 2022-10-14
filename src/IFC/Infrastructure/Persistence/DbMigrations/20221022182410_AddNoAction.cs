using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations
{
    public partial class AddNoAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalRequestTypes",
                table: "Approvals");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovalRequestTypes",
                table: "Approvals",
                column: "ApprovalRequestTypeId",
                principalTable: "ApprovalRequestTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalRequestTypes",
                table: "Approvals");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovalRequestTypes",
                table: "Approvals",
                column: "ApprovalRequestTypeId",
                principalTable: "ApprovalRequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
