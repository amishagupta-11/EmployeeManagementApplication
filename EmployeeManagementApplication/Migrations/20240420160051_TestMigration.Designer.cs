﻿// <auto-generated />
using System;
using EmployeeManagementApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagementApplication.Migrations
{
    [DbContext(typeof(EmployeeManagementContext))]
    [Migration("20240420160051_TestMigration")]
    partial class TestMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDetailsProjects", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "ProjectsProjectId");

                    b.HasIndex("ProjectsProjectId");

                    b.ToTable("EmployeeDetailsProjects");
                });

            modelBuilder.Entity("EmployeeDetailsSkills", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsSkillId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "SkillsSkillId");

                    b.HasIndex("SkillsSkillId");

                    b.ToTable("EmployeeDetailsSkills");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.EmployeeDetails", b =>
                {
                    b.Property<int?>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EmployeeId"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Experience")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Skills", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<int?>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EmployeeDetailsProjects", b =>
                {
                    b.HasOne("EmployeeManagementApplication.Models.EmployeeDetails", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagementApplication.Models.Projects", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeDetailsSkills", b =>
                {
                    b.HasOne("EmployeeManagementApplication.Models.EmployeeDetails", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagementApplication.Models.Skills", null)
                        .WithMany()
                        .HasForeignKey("SkillsSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.EmployeeDetails", b =>
                {
                    b.HasOne("EmployeeManagementApplication.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Projects", b =>
                {
                    b.HasOne("EmployeeManagementApplication.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Skills", b =>
                {
                    b.HasOne("EmployeeManagementApplication.Models.Department", "Department")
                        .WithMany("Skills")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeManagementApplication.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
