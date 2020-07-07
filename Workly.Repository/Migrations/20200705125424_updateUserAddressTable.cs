using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class updateUserAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "UsersAddress");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "UsersAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "UsersAddress",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlatNumber",
                table: "UsersAddress",
                type: "int",
                nullable: true);
        }
    }
}
