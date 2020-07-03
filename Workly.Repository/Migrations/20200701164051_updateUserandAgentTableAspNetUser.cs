using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class updateUserandAgentTableAspNetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AgentAspNetUsersId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Agents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users",
                column: "AgentAspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
