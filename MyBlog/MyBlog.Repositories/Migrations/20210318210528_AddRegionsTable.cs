using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Repositories.Migrations
{
    public partial class AddRegionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Location = table.Column<string>(nullable: false),
                    PointsOfInterest = table.Column<string>(nullable: false),
                    ExternalLink = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
