using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class addForiegnKeyInAgentAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Agents",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgentAspNetUsersId",
                table: "Users",
                column: "AgentAspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentAspNetUsersId",
                table: "Agents",
                column: "AgentAspNetUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AgentAspNetUsersId",
                table: "Agents",
                column: "AgentAspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users",
                column: "AgentAspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AgentAspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AgentAspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentAspNetUsersId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentAspNetUsersId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
