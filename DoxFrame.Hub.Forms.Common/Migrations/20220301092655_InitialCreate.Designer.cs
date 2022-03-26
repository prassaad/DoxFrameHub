﻿// <auto-generated />
using System;
using DoxFrame.Hub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DoxFrame.Hub.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220301092655_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DoxFrame.Hub.Core.AccountAggregate.HubUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("DOB")
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FiscalYearEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FiscalYearStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<Guid>("HubUserId")
                        .HasColumnType("uuid");

                    b.Property<int>("ITExperience")
                        .HasColumnType("integer");

                    b.Property<string>("IdentityUri")
                        .HasColumnType("text");

                    b.Property<bool>("IsAccountAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCertified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHubAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTrial")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("LicenseName")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NoNITExperience")
                        .HasColumnType("integer");

                    b.Property<string>("NoOfBusinessLocations")
                        .HasColumnType("text");

                    b.Property<string>("NoOfCompanies")
                        .HasColumnType("text");

                    b.Property<int>("NoOfTenats")
                        .HasColumnType("integer");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("ResumeDocPath")
                        .HasColumnType("text");

                    b.Property<string>("SID")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<string>("StaffId")
                        .HasColumnType("text");

                    b.Property<int>("TeamSizeLimit")
                        .HasColumnType("integer");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TotalProjectsWorked")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("HubUsers");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.AccountAggregate.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Domain")
                        .HasColumnType("text");

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EnvironmentTag")
                        .HasColumnType("text");

                    b.Property<DateTime>("FiscalYearEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FiscalYearStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("HubUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("IdentityUri")
                        .HasColumnType("text");

                    b.Property<bool>("IsTrial")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("LicenseName")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NoOfBusinessLocations")
                        .HasColumnType("text");

                    b.Property<string>("NoOfCompanies")
                        .HasColumnType("text");

                    b.Property<int>("NoOfTenats")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<int>("TeamSizeLimit")
                        .HasColumnType("integer");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("HubUserId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("EndUserEdit")
                        .HasColumnType("boolean");

                    b.Property<string>("Group")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("HubUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPreDefined")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<byte[]>("Layout")
                        .HasColumnType("bytea");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("OperationType")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("ProcessArea")
                        .HasColumnType("text");

                    b.Property<string>("ProcessName")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("text");

                    b.Property<string>("RequestUri")
                        .HasColumnType("text");

                    b.Property<string>("SubCategory")
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Trigger")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("WorkFlowStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("isPublished")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("DeploymentId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Diagram")
                        .HasColumnType("text");

                    b.Property<bool?>("EndUserEdit")
                        .HasColumnType("boolean");

                    b.Property<string>("Group")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("HubUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPreDefined")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<byte[]>("Layout")
                        .HasColumnType("bytea");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Resource")
                        .HasColumnType("text");

                    b.Property<string>("SubCategory")
                        .HasColumnType("text");

                    b.Property<bool>("Suspended")
                        .HasColumnType("boolean");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("VersionNumber")
                        .HasColumnType("text");

                    b.Property<string>("VersionTag")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppTitle")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("EndDate")
                        .HasColumnType("text");

                    b.Property<Guid>("HubUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("StartDate")
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.AccountAggregate.Tenant", b =>
                {
                    b.HasOne("DoxFrame.Hub.Core.AccountAggregate.HubUser", null)
                        .WithMany("Tenants")
                        .HasForeignKey("HubUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Form", b =>
                {
                    b.HasOne("DoxFrame.Hub.Core.ProjectAggregate.Project", null)
                        .WithMany("Forms")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Process", b =>
                {
                    b.HasOne("DoxFrame.Hub.Core.ProjectAggregate.Project", null)
                        .WithMany("Processes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Project", b =>
                {
                    b.HasOne("DoxFrame.Hub.Core.AccountAggregate.Tenant", null)
                        .WithMany("projects")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.AccountAggregate.HubUser", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.AccountAggregate.Tenant", b =>
                {
                    b.Navigation("projects");
                });

            modelBuilder.Entity("DoxFrame.Hub.Core.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Forms");

                    b.Navigation("Processes");
                });
#pragma warning restore 612, 618
        }
    }
}
