using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Models;

public partial class EmployeesContext : DbContext
{
    public EmployeesContext()
    {
    }

    public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("host = localhost; database = employees; uid = root; pwd = root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EduId).HasName("PRIMARY");

            entity.ToTable("education");

            entity.Property(e => e.EduId).HasColumnName("EduID");
            entity.Property(e => e.EduName)
                .HasMaxLength(100)
                .HasColumnName("eduName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartmentId, "DepartmentID");

            entity.HasIndex(e => e.EduId, "EduID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EduId).HasColumnName("EduID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.StartingDate).HasColumnType("date");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.Edu).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EduId)
                .HasConstraintName("employee_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
