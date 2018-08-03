using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WCSummerCampRegistration.Migrations
{
    public partial class AvailableWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademyCampId = table.Column<int>(nullable: false),
                    WeekStart = table.Column<string>(type: "nvarchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableWeeks_AcademyCamps_AcademyCampId",
                        column: x => x.AcademyCampId,
                        principalTable: "AcademyCamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableWeeks_AcademyCampId",
                table: "AvailableWeeks",
                column: "AcademyCampId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableWeeks");
        }
    }
}
