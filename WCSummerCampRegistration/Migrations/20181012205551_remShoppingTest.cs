using Microsoft.EntityFrameworkCore.Migrations;

namespace WCSummerCampRegistration.Migrations
{
    public partial class remShoppingTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestMe",
                table: "ShoppingCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestMe",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);
        }
    }
}
