using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class edit_localApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HIS",
                table: "LocalApplications",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HIS",
                table: "LocalApplications");
        }
    }
}
