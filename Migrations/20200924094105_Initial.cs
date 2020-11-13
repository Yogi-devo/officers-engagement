using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficerEngagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engagements",
                columns: table => new
                {
                    EngId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerName = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Venue = table.Column<string>(nullable: true),
                    ChairBy = table.Column<string>(nullable: true),
                    Agenda = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engagements", x => x.EngId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engagements");
        }
    }
}
