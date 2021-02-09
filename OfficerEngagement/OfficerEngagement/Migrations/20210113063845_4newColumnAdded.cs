using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficerEngagement.Migrations
{
    public partial class _4newColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfEntry",
                table: "Engagements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingMode",
                table: "Engagements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherParticipant",
                table: "Engagements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Remarks",
                table: "Engagements",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEntry",
                table: "Engagements");

            migrationBuilder.DropColumn(
                name: "MeetingMode",
                table: "Engagements");

            migrationBuilder.DropColumn(
                name: "OtherParticipant",
                table: "Engagements");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Engagements");
        }
    }
}
