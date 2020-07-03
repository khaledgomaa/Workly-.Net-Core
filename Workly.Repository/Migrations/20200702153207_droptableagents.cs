using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class droptableagents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AgentId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "Agent");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agent",
                newName: "IX_Agent_AspNetUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_AspNetUsers_AspNetUsersId",
                table: "Agent",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_AspNetUsers_AspNetUsersId",
                table: "Agent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "Agents");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_AspNetUsersId",
                table: "Agents",
                newName: "IX_Agents_AspNetUsersId");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AgentId",
                table: "Orders",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
