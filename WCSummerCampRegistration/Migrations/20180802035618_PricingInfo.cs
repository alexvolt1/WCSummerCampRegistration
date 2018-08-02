using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WCSummerCampRegistration.Migrations
{
    public partial class PricingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembAcademyAlonePrice = table.Column<decimal>(nullable: false),
                    MembAcademyDayCampPrice = table.Column<decimal>(nullable: false),
                    MembRegPrice = table.Column<decimal>(nullable: false),
                    NonMembAcademyAlonePrice = table.Column<decimal>(nullable: false),
                    NonMembAcademyDayCampPrice = table.Column<decimal>(nullable: false),
                    NonMembRegPrice = table.Column<decimal>(nullable: false)
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
