using Microsoft.EntityFrameworkCore.Migrations;

namespace GorinManagement.Data.Migrations
{
    public partial class ModifyGroupTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupType",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "GroupTypeEnum",
                table: "People",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupTypeEnum",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "GroupType",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
