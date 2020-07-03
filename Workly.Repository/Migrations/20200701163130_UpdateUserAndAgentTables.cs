using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class UpdateUserAndAgentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AgentAspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Agents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AgentAspNetUsersId",
                table: "Agents",
                column: "AgentAspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users",
                column: "AgentAspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AgentAspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AgentAspNetUsersId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AgentAspNetUsersId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
