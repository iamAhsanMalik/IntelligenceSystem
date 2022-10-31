using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations
{
    public partial class UpdatedColumnsSpellings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrgnizationId",
                table: "SuspectProfiles",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_SuspectProfiles_OrgnizationId",
                table: "SuspectProfiles",
                newName: "IX_SuspectProfiles_OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "SuspectProfiles",
                newName: "OrgnizationId");

            migrationBuilder.RenameIndex(
                name: "IX_SuspectProfiles_OrganizationId",
                table: "SuspectProfiles",
                newName: "IX_SuspectProfiles_OrgnizationId");
        }
    }
}
