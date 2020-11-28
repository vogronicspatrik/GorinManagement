using Microsoft.EntityFrameworkCore.Migrations;

namespace GorinManagement.Data.Migrations
{
    public partial class AddGroupTypeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupType",
                table: "People",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupType",
                table: "People");
        }
    }
}
