using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class DeleteJobreferenceFromAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_JobId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_JobId",
                table: "Agents",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
