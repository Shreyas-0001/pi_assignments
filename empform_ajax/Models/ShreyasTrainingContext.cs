using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace empform_ajax.Models;

public partial class ShreyasTrainingContext : DbContext
{
    public ShreyasTrainingContext()
    {
    }

    public ShreyasTrainingContext(DbContextOptions<ShreyasTrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<As1Department> As1Departments { get; set; }

    public virtual DbSet<As1Designation> As1Designations { get; set; }

    public virtual DbSet<As1Employee> As1Employees { get; set; }

    public virtual DbSet<As1Skill> As1Skills { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.200.76\\SQL2016EXPRESS;Database=Shreyas_Training;User Id=test;password=test;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<As1Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__as1_depa__3213E83FD352DA32");

            entity.ToTable("as1_department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<As1Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__as1_desi__3213E83F9F2E4199");

            entity.ToTable("as1_designation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<As1Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__as1_empl__3213E83F7B03E29D");

            entity.ToTable("as1_employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("date")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Designationid).HasColumnName("designationid");
            entity.Property(e => e.Doj)
                .HasColumnType("date")
                .HasColumnName("doj");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.As1Employees)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("FK_departmentid");

            entity.HasOne(d => d.Designation).WithMany(p => p.As1Employees)
                .HasForeignKey(d => d.Designationid)
                .HasConstraintName("FK_designationid");

            entity.HasMany(d => d.Skills).WithMany(p => p.Emps)
                .UsingEntity<Dictionary<string, object>>(
                    "As1Empskill",
                    r => r.HasOne<As1Skill>().WithMany()
                        .HasForeignKey("Skillid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_skill"),
                    l => l.HasOne<As1Employee>().WithMany()
                        .HasForeignKey("Empid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_emp"),
                    j =>
                    {
                        j.HasKey("Empid", "Skillid").HasName("PK_Name");
                        j.ToTable("as1_empskill");
                    });
        });

        modelBuilder.Entity<As1Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__as1_skil__3213E83FB84260B7");

            entity.ToTable("as1_skill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
