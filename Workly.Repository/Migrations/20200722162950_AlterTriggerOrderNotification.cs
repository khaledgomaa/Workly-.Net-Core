using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class AlterTriggerOrderNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"alter TRIGGER Addnotification ON orders
                                    AFTER INSERT
                                AS

                                    INSERT INTO Notifications
                                        (orderid,AgentId)
                                    SELECT
                                            id,AgentId
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
