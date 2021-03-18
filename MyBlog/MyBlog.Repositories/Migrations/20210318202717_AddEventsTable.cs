using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Repositories.Migrations
{
    public partial class AddEventsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    OrganizedBy = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
