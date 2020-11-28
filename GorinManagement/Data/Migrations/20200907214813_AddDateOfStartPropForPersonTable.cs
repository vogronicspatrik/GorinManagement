using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GorinManagement.Data.Migrations
{
    public partial class AddDateOfStartPropForPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfStart",
                table: "People",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfStart",
                table: "People");
        }
    }
}
