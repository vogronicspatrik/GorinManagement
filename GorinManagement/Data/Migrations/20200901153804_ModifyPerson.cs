using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GorinManagement.Data.Migrations
{
    public partial class ModifyPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "People",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PersonAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    DateOfTraining = table.Column<DateTime>(nullable: false),
                    IsAttended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAttendance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAttendance");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "People");
        }
    }
}
