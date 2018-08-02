using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WCSummerCampRegistration.Migrations
{
    public partial class PolicyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptableUnacceptableBehavior = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    CommunicatingAnEmergency = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    DropOffProcedure = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Illness = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    LatePickUp = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    LateRegistration = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Medicine = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    NecessaryForms = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    PhotoConsent = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    PickUpProcedure = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    PoliciesAndProcedures = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    ReportingChildAbuse = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    SafetyPolicy = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Visiting = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    WhatToBring = table.Column<string>(type: "nvarchar(4000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
