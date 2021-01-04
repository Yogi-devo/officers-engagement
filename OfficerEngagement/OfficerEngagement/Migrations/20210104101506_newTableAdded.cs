using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficerEngagement.Migrations
{
    public partial class newTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empcode = table.Column<string>(nullable: false),
                    empname = table.Column<string>(nullable: false),
                    sex = table.Column<string>(nullable: false),
                    dateofjoininggovt = table.Column<DateTime>(nullable: false),
                    dateofjoiningdhi = table.Column<DateTime>(nullable: false),
                    dateofbirth = table.Column<DateTime>(nullable: false),
                    dateofretirement = table.Column<DateTime>(nullable: false),
                    pan_no = table.Column<string>(nullable: true),
                    address_permanent = table.Column<string>(nullable: true),
                    mobileno = table.Column<string>(nullable: true),
                    roomno = table.Column<string>(nullable: true),
                    intercom = table.Column<int>(nullable: false),
                    emailaddress = table.Column<string>(nullable: true),
                    paylevel = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.SerialNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
