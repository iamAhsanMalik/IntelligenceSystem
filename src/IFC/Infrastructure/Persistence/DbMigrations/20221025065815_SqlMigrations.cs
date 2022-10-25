using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFC.Infrastructure.Persistence.DbMigrations
{
    public partial class SqlMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocalAffiliate = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ForiegnAffiliate = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequestTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestType = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FundingSource = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Involvements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Involvements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(8, 6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9, 6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationalBases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationalBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectorHeadQuarter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorHeadQuarter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SocialMediaProfile = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerroristInvolvements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Involvement = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristInvolvements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 125, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 125, nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    ProfileImage = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApprovalRequestTypeId = table.Column<long>(type: "INTEGER", nullable: true),
                    InitiatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ApprovalStatus = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_ApprovalRequestTypes",
                        column: x => x.ApprovalRequestTypeId,
                        principalTable: "ApprovalRequestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Streat = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    CityId = table.Column<long>(type: "INTEGER", nullable: true),
                    DistrictId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Address_District",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SuspectFamilyDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    RelationTypeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspectFamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuspectFamilyDetails_RelationTypes",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoreHeadQuarter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SectorHeadQuarterId = table.Column<long>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreHeadQuarter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreHeadQuarter_SectorHeadQuarter",
                        column: x => x.SectorHeadQuarterId,
                        principalTable: "SectorHeadQuarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerroristFacilitatorsDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    TribeOrCast = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Sect = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    RelationTypeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristFacilitatorsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerroristFacilitatorsDetails_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristFacilitatorsDetails_RelationTypes",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TerroristFamilyDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    TribeOrCast = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Sect = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    RelationTypeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristFamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerroristFamilyDetails_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristFamilyDetails_RelationTypes",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Wing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsSACAApplied = table.Column<bool>(type: "INTEGER", nullable: true),
                    SACAType = table.Column<int>(type: "INTEGER", nullable: true),
                    WingType = table.Column<int>(type: "INTEGER", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    CoreHeadQuarterId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wing_CoreHeadQuarter",
                        column: x => x.CoreHeadQuarterId,
                        principalTable: "CoreHeadQuarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IncidentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    SuspectsProfileId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: true),
                    WingId = table.Column<long>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Incidents_Wing",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationFunders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FunderId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationFunders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationFunders_Funders",
                        column: x => x.FunderId,
                        principalTable: "Funders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    TotalMembers = table.Column<long>(type: "INTEGER", nullable: true),
                    YearFounded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ThreatLevel = table.Column<byte>(type: "INTEGER", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    AffiliateId = table.Column<long>(type: "INTEGER", nullable: true),
                    OperationalBaseId = table.Column<long>(type: "INTEGER", nullable: true),
                    InvolvementId = table.Column<long>(type: "INTEGER", nullable: true),
                    SocialMediaProfileId = table.Column<long>(type: "INTEGER", nullable: true),
                    TerroristProfileId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Affiliates",
                        column: x => x.AffiliateId,
                        principalTable: "Affiliates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Organizations_Involvements",
                        column: x => x.InvolvementId,
                        principalTable: "Involvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Organizations_OperationalBases",
                        column: x => x.OperationalBaseId,
                        principalTable: "OperationalBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Organizations_SocialMediaProfiles",
                        column: x => x.SocialMediaProfileId,
                        principalTable: "SocialMediaProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SuspectProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    TribeOrCast = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Sect = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "INTEGER", nullable: true),
                    GeneralRemarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrgnizationId = table.Column<long>(type: "INTEGER", nullable: true),
                    SuspectFamilyDetailsId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspectProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuspectProfiles_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SuspectProfiles_Organizations",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SuspectProfiles_SuspectFamilyDetails",
                        column: x => x.SuspectFamilyDetailsId,
                        principalTable: "SuspectFamilyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TerroristProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    NameAlias = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    TribeOrCast = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Sect = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CNIC = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsFounder = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    GeneralRemarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    AddressId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrgnizationId = table.Column<long>(type: "INTEGER", nullable: true),
                    TerroristInvolvementId = table.Column<long>(type: "INTEGER", nullable: true),
                    TerroristFamilyDetailsId = table.Column<long>(type: "INTEGER", nullable: true),
                    TerroristFacilitatorsDetailsId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerroristProfiles_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristProfiles_Organizations",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristProfiles_TerroristFacilitatorsDetails",
                        column: x => x.TerroristFacilitatorsDetailsId,
                        principalTable: "TerroristFacilitatorsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristProfiles_TerroristFamilyDetails",
                        column: x => x.TerroristFamilyDetailsId,
                        principalTable: "TerroristFamilyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TerroristProfiles_TerroristInvolvements",
                        column: x => x.TerroristInvolvementId,
                        principalTable: "TerroristInvolvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThreatDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ThreatLevel = table.Column<byte>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))"),
                    WingId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: true),
                    SuspectsProfileId = table.Column<long>(type: "INTEGER", nullable: true),
                    IncidentId = table.Column<long>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_Incidents",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Threats_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Threats_Organizations",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Threats_SuspectProfiles",
                        column: x => x.SuspectsProfileId,
                        principalTable: "SuspectProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Threats_Wing",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApprovalRequestTypeId",
                table: "Approvals",
                column: "ApprovalRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreHeadQuarter_SectorHeadQuarterId",
                table: "CoreHeadQuarter",
                column: "SectorHeadQuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_LocationId",
                table: "Incidents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_OrganizationId",
                table: "Incidents",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_SuspectsProfileId",
                table: "Incidents",
                column: "SuspectsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_WingId",
                table: "Incidents",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFunders_FunderId",
                table: "OrganizationFunders",
                column: "FunderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFunders_OrganizationId",
                table: "OrganizationFunders",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AffiliateId",
                table: "Organizations",
                column: "AffiliateId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_InvolvementId",
                table: "Organizations",
                column: "InvolvementId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OperationalBaseId",
                table: "Organizations",
                column: "OperationalBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_SocialMediaProfileId",
                table: "Organizations",
                column: "SocialMediaProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_TerroristProfileId",
                table: "Organizations",
                column: "TerroristProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuspectFamilyDetails_RelationTypeId",
                table: "SuspectFamilyDetails",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspectProfiles_AddressId",
                table: "SuspectProfiles",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspectProfiles_OrgnizationId",
                table: "SuspectProfiles",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspectProfiles_SuspectFamilyDetailsId",
                table: "SuspectProfiles",
                column: "SuspectFamilyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristFacilitatorsDetails_AddressId",
                table: "TerroristFacilitatorsDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristFacilitatorsDetails_RelationTypeId",
                table: "TerroristFacilitatorsDetails",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristFamilyDetails_AddressId",
                table: "TerroristFamilyDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristFamilyDetails_RelationTypeId",
                table: "TerroristFamilyDetails",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristProfiles_AddressId",
                table: "TerroristProfiles",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristProfiles_OrgnizationId",
                table: "TerroristProfiles",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristProfiles_TerroristFacilitatorsDetailsId",
                table: "TerroristProfiles",
                column: "TerroristFacilitatorsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristProfiles_TerroristFamilyDetailsId",
                table: "TerroristProfiles",
                column: "TerroristFamilyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristProfiles_TerroristInvolvementId",
                table: "TerroristProfiles",
                column: "TerroristInvolvementId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_IncidentId",
                table: "Threats",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_LocationId",
                table: "Threats",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_OrganizationId",
                table: "Threats",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_SuspectsProfileId",
                table: "Threats",
                column: "SuspectsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_WingId",
                table: "Threats",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wing_CoreHeadQuarterId",
                table: "Wing",
                column: "CoreHeadQuarterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Organizations",
                table: "Incidents",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_SuspectProfiles",
                table: "Incidents",
                column: "SuspectsProfileId",
                principalTable: "SuspectProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationFunders_Organizations",
                table: "OrganizationFunders",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_TerroristProfiles_TerroristProfileId",
                table: "Organizations",
                column: "TerroristProfileId",
                principalTable: "TerroristProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_TerroristProfiles_Organizations",
                table: "TerroristProfiles");

            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "OrganizationFunders");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ApprovalRequestTypes");

            migrationBuilder.DropTable(
                name: "Funders");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "SuspectProfiles");

            migrationBuilder.DropTable(
                name: "Wing");

            migrationBuilder.DropTable(
                name: "SuspectFamilyDetails");

            migrationBuilder.DropTable(
                name: "CoreHeadQuarter");

            migrationBuilder.DropTable(
                name: "SectorHeadQuarter");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Affiliates");

            migrationBuilder.DropTable(
                name: "Involvements");

            migrationBuilder.DropTable(
                name: "OperationalBases");

            migrationBuilder.DropTable(
                name: "SocialMediaProfiles");

            migrationBuilder.DropTable(
                name: "TerroristProfiles");

            migrationBuilder.DropTable(
                name: "TerroristFacilitatorsDetails");

            migrationBuilder.DropTable(
                name: "TerroristFamilyDetails");

            migrationBuilder.DropTable(
                name: "TerroristInvolvements");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "RelationTypes");
        }
    }
}
