using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WCSummerCampRegistration.Migrations
{
    public partial class addPricing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembRegPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    NonMembRegPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    MembAcademyAlonePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    NonMembAcademyAlonePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    MembAcademyDayCampPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    NonMembAcademyDayCampPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricings");
        }
    }
}
