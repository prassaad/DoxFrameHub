using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoxFrame.Hub.Infrastructure.Migrations
{
    public partial class workflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    FiscalYearStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FiscalYearEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    FiscalYearStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FiscalYearEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                name: "IX_Projects_TenantId",
                table: "Projects",
                column: "TenantId");

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
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Workflows");

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
