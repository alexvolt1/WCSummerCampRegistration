using Microsoft.EntityFrameworkCore.Migrations;

namespace WCSummerCampRegistration.Migrations
{
    public partial class addisAvailableToCamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "Camps",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "Camps");
        }
    }
}
