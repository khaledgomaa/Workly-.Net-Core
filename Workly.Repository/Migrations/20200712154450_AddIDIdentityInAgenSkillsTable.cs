using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class AddIDIdentityInAgenSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentSkills",
                table: "AgentSkills");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AgentSkills",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentSkills",
                table: "AgentSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSkills_AgentId",
                table: "AgentSkills",
                column: "AgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentSkills",
                table: "AgentSkills");

            migrationBuilder.DropIndex(
                name: "IX_AgentSkills_AgentId",
                table: "AgentSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AgentSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentSkills",
                table: "AgentSkills",
                columns: new[] { "AgentId", "SkillId" });
        }
    }
}
