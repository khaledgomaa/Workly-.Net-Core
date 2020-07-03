using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class updateAgentAndOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersId",
                table: "Agents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Agents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AgentId",
                table: "Orders",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_JobId",
                table: "Agents",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AgentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_JobId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                unique: true,
                filter: "[AspNetUsersId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
