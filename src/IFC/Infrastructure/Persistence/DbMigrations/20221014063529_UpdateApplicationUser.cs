using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations;

public partial class UpdateApplicationUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ProfileImage",
            table: "Users",
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ProfileImage",
            table: "Users");
    }
}
