using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class AddInsertIntoOrderProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc InsertIntoOrder @user_id int , @agent_id int ,
                                                             @loc varchar(50) , @mydate Date , @rate decimal 
                                 as
                                   insert into Orders(UserId,AgentId,Location,Date,AgentRate)
                                   values(@user_id,@agent_id,@loc,@mydate,@rate)";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop proc InsertIntoOrder";
            migrationBuilder.Sql(procedure);
        }
    }
}
