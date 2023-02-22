﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using empform_ajax.Models;

#nullable disable

namespace empformajax.Migrations
{
    [DbContext(typeof(ShreyasTrainingContext))]
    partial class ShreyasTrainingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("As1Empskill", b =>
                {
                    b.Property<int>("Empid")
                        .HasColumnType("int");

                    b.Property<int>("Skillid")
                        .HasColumnType("int");

                    b.HasKey("Empid", "Skillid")
                        .HasName("PK_Name");

                    b.HasIndex("Skillid");

                    b.ToTable("as1_empskill", (string)null);
                });

            modelBuilder.Entity("empform_ajax.Models.As1Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__as1_depa__3213E83FD352DA32");

                    b.ToTable("as1_department", (string)null);
                });

            modelBuilder.Entity("empform_ajax.Models.As1Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__as1_desi__3213E83F9F2E4199");

                    b.ToTable("as1_designation", (string)null);
                });

            modelBuilder.Entity("empform_ajax.Models.As1Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Dateofbirth")
                        .HasColumnType("date")
                        .HasColumnName("dateofbirth");

                    b.Property<int?>("Departmentid")
                        .HasColumnType("int")
                        .HasColumnName("departmentid");

                    b.Property<int?>("Designationid")
                        .HasColumnType("int")
                        .HasColumnName("designationid");

                    b.Property<DateTime?>("Doj")
                        .HasColumnType("date")
                        .HasColumnName("doj");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("firstname");

                    b.Property<string>("Gender")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("gender");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("lastname");

                    b.Property<int?>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.HasKey("Id")
                        .HasName("PK__as1_empl__3213E83F7B03E29D");

                    b.HasIndex("Departmentid");

                    b.HasIndex("Designationid");

                    b.ToTable("as1_employee", (string)null);
                });

            modelBuilder.Entity("empform_ajax.Models.As1Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__as1_skil__3213E83FB84260B7");

                    b.ToTable("as1_skill", (string)null);
                });

            modelBuilder.Entity("As1Empskill", b =>
                {
                    b.HasOne("empform_ajax.Models.As1Employee", null)
                        .WithMany()
                        .HasForeignKey("Empid")
                        .IsRequired()
                        .HasConstraintName("FK_emp");

                    b.HasOne("empform_ajax.Models.As1Skill", null)
                        .WithMany()
                        .HasForeignKey("Skillid")
                        .IsRequired()
                        .HasConstraintName("FK_skill");
                });

            modelBuilder.Entity("empform_ajax.Models.As1Employee", b =>
                {
                    b.HasOne("empform_ajax.Models.As1Department", "Department")
                        .WithMany("As1Employees")
                        .HasForeignKey("Departmentid")
                        .HasConstraintName("FK_departmentid");

                    b.HasOne("empform_ajax.Models.As1Designation", "Designation")
                        .WithMany("As1Employees")
                        .HasForeignKey("Designationid")
                        .HasConstraintName("FK_designationid");

                    b.Navigation("Department");

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("empform_ajax.Models.As1Department", b =>
                {
                    b.Navigation("As1Employees");
                });

            modelBuilder.Entity("empform_ajax.Models.As1Designation", b =>
                {
                    b.Navigation("As1Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
