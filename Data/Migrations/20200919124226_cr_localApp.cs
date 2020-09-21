using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class cr_localApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestWard_Locations_LocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.DropIndex(
                name: "IX_RequestWard_LocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.DropColumn(
                name: "LocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "UIS",
                table: "AppUsers",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterServiceGroupCategory",
                columns: table => new
                {
                    MSGID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MSCategoryName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MSGParentID = table.Column<int>(nullable: false),
                    CategoryMSGID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterServiceGroupCategory", x => x.MSGID);
                    table.ForeignKey(
                        name: "FK_MasterServiceGroupCategory_MasterServiceGroupCategory_CategoryMSGID",
                        column: x => x.CategoryMSGID,
                        principalTable: "MasterServiceGroupCategory",
                        principalColumn: "MSGID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalApplications",
                schema: "HIS",
                columns: table => new
                {
                    LocalAppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    IsLocalApp = table.Column<bool>(nullable: false),
                    ApplicationPath = table.Column<string>(maxLength: 1000, nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalApplications", x => x.LocalAppID);
                });

            migrationBuilder.CreateTable(
                name: "MasterServices",
                columns: table => new
                {
                    MasterServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterServiceName = table.Column<string>(nullable: true),
                    ServiceDisplayName = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    ServiceGroupCategoryID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MSParentID = table.Column<int>(nullable: false),
                    MasterServicesMasterServiceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterServices", x => x.MasterServiceID);
                    table.ForeignKey(
                        name: "FK_MasterServices_MasterServices_MasterServicesMasterServiceID",
                        column: x => x.MasterServicesMasterServiceID,
                        principalTable: "MasterServices",
                        principalColumn: "MasterServiceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterServices_MasterServiceGroupCategory_ServiceGroupCategoryID",
                        column: x => x.ServiceGroupCategoryID,
                        principalTable: "MasterServiceGroupCategory",
                        principalColumn: "MSGID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard",
                column: "LocationsLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterServiceGroupCategory_CategoryMSGID",
                table: "MasterServiceGroupCategory",
                column: "CategoryMSGID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterServices_MasterServicesMasterServiceID",
                table: "MasterServices",
                column: "MasterServicesMasterServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterServices_ServiceGroupCategoryID",
                table: "MasterServices",
                column: "ServiceGroupCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestWard_Locations_LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard",
                column: "LocationsLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestWard_Locations_LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.DropTable(
                name: "MasterServices");

            migrationBuilder.DropTable(
                name: "LocalApplications",
                schema: "HIS");

            migrationBuilder.DropTable(
                name: "MasterServiceGroupCategory");

            migrationBuilder.DropIndex(
                name: "IX_RequestWard_LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.DropColumn(
                name: "LocationsLocationID",
                schema: "HDIS",
                table: "RequestWard");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "UIS",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                schema: "HDIS",
                table: "RequestWard",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_LocationID",
                schema: "HDIS",
                table: "RequestWard",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestWard_Locations_LocationID",
                schema: "HDIS",
                table: "RequestWard",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
