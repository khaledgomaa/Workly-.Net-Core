using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class ADDTriggerOnOrderAfterInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create TRIGGER Addnotification ON orders
                                    AFTER INSERT
                                AS

                                    INSERT INTO Notifications
                                        (orderid)
                                    SELECT
                                            id
                                    FROM inserted

                                    go";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop trigger Addnotification";
            migrationBuilder.Sql(procedure);
        }
    }
}
