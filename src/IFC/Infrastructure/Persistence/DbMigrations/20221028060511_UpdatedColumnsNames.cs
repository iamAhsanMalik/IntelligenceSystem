using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations
{
    public partial class UpdatedColumnsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrgnizationId",
                table: "TerroristProfiles",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_TerroristProfiles_OrgnizationId",
                table: "TerroristProfiles",
                newName: "IX_TerroristProfiles_OrganizationId");

            migrationBuilder.RenameColumn(
                name: "ForiegnAffiliate",
                table: "Affiliates",
                newName: "ForeignAffiliate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "TerroristProfiles",
                newName: "OrgnizationId");

            migrationBuilder.RenameIndex(
                name: "IX_TerroristProfiles_OrganizationId",
                table: "TerroristProfiles",
                newName: "IX_TerroristProfiles_OrgnizationId");

            migrationBuilder.RenameColumn(
                name: "ForeignAffiliate",
                table: "Affiliates",
                newName: "ForiegnAffiliate");
        }
    }
}
