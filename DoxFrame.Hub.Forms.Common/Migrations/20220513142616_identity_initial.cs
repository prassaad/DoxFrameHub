using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoxFrame.Hub.Infrastructure.Migrations
{
    public partial class identity_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HubUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    SID = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<string>(type: "text", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    StaffId = table.Column<string>(type: "text", nullable: true),
                    IsAccountAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    IsHubAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    ITExperience = table.Column<int>(type: "integer", nullable: false),
                    NoNITExperience = table.Column<int>(type: "integer", nullable: false),
                    TotalProjectsWorked = table.Column<int>(type: "integer", nullable: false),
                    ResumeDocPath = table.Column<string>(type: "text", nullable: true),
                    IsCertified = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    IdentityUri = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Domain = table.Column<string>(type: "text", nullable: true),
                    NoOfTenats = table.Column<int>(type: "integer", nullable: false),
                    FiscalYearStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FiscalYearEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsTrial = table.Column<bool>(type: "boolean", nullable: false),
                    LicenseName = table.Column<string>(type: "text", nullable: true),
                    NoOfCompanies = table.Column<string>(type: "text", nullable: true),
                    NoOfBusinessLocations = table.Column<string>(type: "text", nullable: true),
                    TeamSizeLimit = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DomainName = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    EnvironmentTag = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    IdentityUri = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Domain = table.Column<string>(type: "text", nullable: true),
                    NoOfTenats = table.Column<int>(type: "integer", nullable: false),
                    FiscalYearStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FiscalYearEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsTrial = table.Column<bool>(type: "boolean", nullable: false),
                    LicenseName = table.Column<string>(type: "text", nullable: true),
                    NoOfCompanies = table.Column<string>(type: "text", nullable: true),
                    NoOfBusinessLocations = table.Column<string>(type: "text", nullable: true),
                    TeamSizeLimit = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_HubUsers_HubUserId",
                        column: x => x.HubUserId,
                        principalTable: "HubUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AppTitle = table.Column<string>(type: "text", nullable: true),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParetnId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ComponentType = table.Column<string>(type: "text", nullable: true),
                    SubCategory = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    IsGroup = table.Column<bool>(type: "boolean", maxLength: 200, nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    EndUserEdit = table.Column<bool>(type: "boolean", nullable: true),
                    IsPreDefined = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Layout = table.Column<byte[]>(type: "bytea", nullable: true),
                    PageGroupName = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    isPublished = table.Column<bool>(type: "boolean", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Layout = table.Column<byte[]>(type: "bytea", nullable: true),
                    ReportGroupName = table.Column<string>(type: "text", nullable: true),
                    ReportType = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    RequestUri = table.Column<string>(type: "text", nullable: true),
                    isPublished = table.Column<bool>(type: "boolean", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Layout = table.Column<byte[]>(type: "bytea", nullable: true),
                    OperationType = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    Trigger = table.Column<string>(type: "text", nullable: true),
                    RequestMethod = table.Column<string>(type: "text", nullable: true),
                    RequestUri = table.Column<string>(type: "text", nullable: true),
                    isPublished = table.Column<bool>(type: "boolean", nullable: false),
                    WorkFlowStatus = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Layout = table.Column<byte[]>(type: "bytea", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    VersionNumber = table.Column<string>(type: "text", nullable: true),
                    Resource = table.Column<string>(type: "text", nullable: true),
                    DeploymentId = table.Column<string>(type: "text", nullable: true),
                    Diagram = table.Column<string>(type: "text", nullable: true),
                    Suspended = table.Column<bool>(type: "boolean", nullable: false),
                    VersionTag = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByName = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedTime = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByName = table.Column<Guid>(type: "uuid", nullable: false),
                    HubUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflows_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workflows_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_ProjectId",
                table: "Components",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ComponentId",
                table: "Forms",
                column: "ComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ProjectId",
                table: "Forms",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_ProjectId",
                table: "Page",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TenantId",
                table: "Projects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProjectId",
                table: "Report",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_HubUserId",
                table: "Tenants",
                column: "HubUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ComponentId",
                table: "Workflows",
                column: "ComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ProjectId",
                table: "Workflows",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "HubUsers");
        }
    }
}
