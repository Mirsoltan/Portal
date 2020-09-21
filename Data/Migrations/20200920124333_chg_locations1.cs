using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class chg_locations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondaryLocationType",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "baseLocationType",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryLocationType",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "baseLocationType",
                table: "Locations");
        }
    }
}
