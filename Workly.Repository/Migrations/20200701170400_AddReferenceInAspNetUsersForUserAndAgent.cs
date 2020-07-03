using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class AddReferenceInAspNetUsersForUserAndAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Agents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Agents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AspNetUsersId",
                table: "Agents",
                column: "AspNetUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Jobs_JobId",
                table: "Agents",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
