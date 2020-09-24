using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DAMS.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomEventModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NotifyBefore = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEventModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NotifyBefore = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    PeriodType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NotifyBefore = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyEventsModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CustomEventId = table.Column<int>(nullable: false),
                    CustomEventModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEventsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyEventsModels_CustomEventModels_CustomEventModelId",
                        column: x => x.CustomEventModelId,
                        principalTable: "CustomEventModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyEventsModels_CustomEventModelId",
                table: "MyEventsModels",
                column: "CustomEventModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyEventsModels");

            migrationBuilder.DropTable(
                name: "OneTimeEvents");

            migrationBuilder.DropTable(
                name: "PeriodEvents");

            migrationBuilder.DropTable(
                name: "CustomEventModels");
        }
    }
}
