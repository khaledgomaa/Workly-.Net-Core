﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Workly.Repository.Migrations
{
    public partial class UpdatestatusinnotificationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
               name: "status",
               table: "Notifications",
               nullable: false,
               defaultValueSql: "'false'",
               oldClrType: typeof(byte),
               oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
    name: "status",
    table: "Notifications",
    type: "tinyint",
    nullable: false,
    oldClrType: typeof(bool));
        }
    }
}
