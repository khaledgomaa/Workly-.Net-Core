using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class UpdateTableUserAddressAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "UsersAddress",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlatNumber",
                table: "UsersAddress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "UsersAddress");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "UsersAddress");
        }
    }
}
