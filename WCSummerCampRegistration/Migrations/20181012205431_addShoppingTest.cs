using Microsoft.EntityFrameworkCore.Migrations;

namespace WCSummerCampRegistration.Migrations
{
    public partial class addShoppingTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestMe",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestMe",
                table: "ShoppingCart");
        }
    }
}
