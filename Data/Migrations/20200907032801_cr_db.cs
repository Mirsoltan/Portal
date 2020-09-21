using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class cr_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HIS");

            migrationBuilder.EnsureSchema(
                name: "HDIS");

            migrationBuilder.EnsureSchema(
                name: "UIS");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(maxLength: 200, nullable: false),
                    ParentLocationID = table.Column<int>(nullable: true),
                    IconAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_ParentLocationID",
                        column: x => x.ParentLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "HIS",
                columns: table => new
                {
                    DoctorsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerSpeciality = table.Column<int>(nullable: false),
                    PractitionerJobCategory = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    RegisterationNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorsID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "HIS",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 700, nullable: true),
                    HomeTel = table.Column<string>(maxLength: 11, nullable: true),
                    TelNo1 = table.Column<string>(maxLength: 11, nullable: true),
                    Mobile = table.Column<string>(maxLength: 11, nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    EducationLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                schema: "UIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "UIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    RegisterDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    Bio = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    HomeTel = table.Column<string>(nullable: true),
                    TelNo1 = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    EducationLevel = table.Column<int>(nullable: false),
                    AssistType = table.Column<int>(nullable: false),
                    RegisterationNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestWard",
                schema: "HDIS",
                columns: table => new
                {
                    RequestWardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    RequestStatusType = table.Column<int>(nullable: false),
                    RequestPriorityType = table.Column<int>(nullable: false),
                    DemanderWardID = table.Column<int>(nullable: false),
                    RecepterWardID = table.Column<int>(nullable: false),
                    ParentRequestWardID = table.Column<int>(nullable: true),
                    IsRefered = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestWard", x => x.RequestWardID);
                    table.ForeignKey(
                        name: "FK_RequestWard_Locations_DemanderWardID",
                        column: x => x.DemanderWardID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestWard_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestWard_RequestWard_ParentRequestWardID",
                        column: x => x.ParentRequestWardID,
                        principalSchema: "HDIS",
                        principalTable: "RequestWard",
                        principalColumn: "RequestWardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestWard_Locations_RecepterWardID",
                        column: x => x.RecepterWardID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaim",
                schema: "UIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaim_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "UIS",
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admission",
                schema: "HIS",
                columns: table => new
                {
                    AdmissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AdmissionType = table.Column<int>(nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: true),
                    AdmissionStatus = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    PractitionerID = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission", x => x.AdmissionID);
                    table.ForeignKey(
                        name: "FK_Admission_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalSchema: "HIS",
                        principalTable: "Doctors",
                        principalColumn: "DoctorsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Patient_PatientID",
                        column: x => x.PatientID,
                        principalSchema: "HIS",
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admission_AppUsers_PractitionerID",
                        column: x => x.PractitionerID,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_AppUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaim",
                schema: "UIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaim_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                schema: "UIS",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "UIS",
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "UIS",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParentLocationID",
                table: "Locations",
                column: "ParentLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_DemanderWardID",
                schema: "HDIS",
                table: "RequestWard",
                column: "DemanderWardID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_LocationID",
                schema: "HDIS",
                table: "RequestWard",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_ParentRequestWardID",
                schema: "HDIS",
                table: "RequestWard",
                column: "ParentRequestWardID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestWard_RecepterWardID",
                schema: "HDIS",
                table: "RequestWard",
                column: "RecepterWardID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_DoctorID",
                schema: "HIS",
                table: "Admission",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_LocationID",
                schema: "HIS",
                table: "Admission",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_PatientID",
                schema: "HIS",
                table: "Admission",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_PractitionerID",
                schema: "HIS",
                table: "Admission",
                column: "PractitionerID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_UserID",
                schema: "HIS",
                table: "Admission",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaim_RoleId",
                schema: "UIS",
                table: "AppRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "UIS",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaim_UserId",
                schema: "UIS",
                table: "AppUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                schema: "UIS",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "UIS",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "UIS",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RequestWard",
                schema: "HDIS");

            migrationBuilder.DropTable(
                name: "Admission",
                schema: "HIS");

            migrationBuilder.DropTable(
                name: "AppRoleClaim",
                schema: "UIS");

            migrationBuilder.DropTable(
                name: "AppUserClaim",
                schema: "UIS");

            migrationBuilder.DropTable(
                name: "AppUserRole",
                schema: "UIS");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "HIS");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "HIS");

            migrationBuilder.DropTable(
                name: "AppRoles",
                schema: "UIS");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "UIS");
        }
    }
}
