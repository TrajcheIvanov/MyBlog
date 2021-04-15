using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Repositories.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EvenTypes_EventTypeId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EvenTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EvenTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EvenTypes_EventTypeId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EvenTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EvenTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
