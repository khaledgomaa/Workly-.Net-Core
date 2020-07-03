using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class updateAgentTableAspNetForiegnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersId",
                table: "Agents",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsersId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
