using Microsoft.EntityFrameworkCore.Migrations;

namespace DAMS.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyEventsModels_CustomEventModels_CustomEventModelId",
                table: "MyEventsModels");

            migrationBuilder.DropColumn(
                name: "CustomEventId",
                table: "MyEventsModels");

            migrationBuilder.AlterColumn<int>(
                name: "CustomEventModelId",
                table: "MyEventsModels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyEventsModels_CustomEventModels_CustomEventModelId",
                table: "MyEventsModels",
                column: "CustomEventModelId",
                principalTable: "CustomEventModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyEventsModels_CustomEventModels_CustomEventModelId",
                table: "MyEventsModels");

            migrationBuilder.AlterColumn<int>(
                name: "CustomEventModelId",
                table: "MyEventsModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CustomEventId",
                table: "MyEventsModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MyEventsModels_CustomEventModels_CustomEventModelId",
                table: "MyEventsModels",
                column: "CustomEventModelId",
                principalTable: "CustomEventModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
