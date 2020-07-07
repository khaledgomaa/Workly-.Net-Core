using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class AddExperienceColumnInAgentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Agents",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Agents");
        }
    }
}
