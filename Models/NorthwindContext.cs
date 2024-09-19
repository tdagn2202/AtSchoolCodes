﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ADO2.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customerdemographic> Customerdemographics { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Salesorder> Salesorders { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost; database=Northwind;\nuid=root; password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(15)
                .HasColumnName("categoryName");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Picture)
                .HasColumnType("blob")
                .HasColumnName("picture");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasColumnName("companyName");
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasColumnName("contactName");
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30)
                .HasColumnName("contactTitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Mobile)
                .HasMaxLength(24)
                .HasColumnName("mobile");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");

            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Custs)
                .UsingEntity<Dictionary<string, object>>(
                    "Custcustdemographic",
                    r => r.HasOne<Customerdemographic>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("custcustdemographics_ibfk_2"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("custcustdemographics_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CustId", "CustomerTypeId").HasName("PRIMARY");
                        j.ToTable("custcustdemographics");
                        j.HasIndex(new[] { "CustomerTypeId" }, "customerTypeId");
                        j.IndexerProperty<int>("CustId").HasColumnName("custId");
                        j.IndexerProperty<int>("CustomerTypeId").HasColumnName("customerTypeId");
                    });
        });

        modelBuilder.Entity<Customerdemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PRIMARY");

            entity.ToTable("customerdemographics");

            entity.Property(e => e.CustomerTypeId).HasColumnName("customerTypeId");
            entity.Property(e => e.CustomerDesc)
                .HasColumnType("text")
                .HasColumnName("customerDesc");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthDate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.Extension)
                .HasMaxLength(4)
                .HasColumnName("extension");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hireDate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.MgrId).HasColumnName("mgrId");
            entity.Property(e => e.Mobile)
                .HasMaxLength(24)
                .HasColumnName("mobile");
            entity.Property(e => e.Notes)
                .HasColumnType("blob")
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnType("blob")
                .HasColumnName("photo");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(255)
                .HasColumnName("photoPath");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasColumnName("titleOfCourtesy");

            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeeterritory",
                    r => r.HasOne<Territory>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeeterritory_ibfk_2"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeeterritory_ibfk_1"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId").HasName("PRIMARY");
                        j.ToTable("employeeterritory");
                        j.HasIndex(new[] { "TerritoryId" }, "territoryId");
                        j.IndexerProperty<int>("EmployeeId")
                            .ValueGeneratedOnAdd()
                            .HasColumnName("employeeId");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("territoryId");
                    });
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.HasIndex(e => e.OrderId, "orderId");

            entity.HasIndex(e => e.ProductId, "productId");

            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailId");
            entity.Property(e => e.Discount)
                .HasPrecision(10)
                .HasColumnName("discount");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10)
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_ibfk_2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "categoryId");

            entity.HasIndex(e => e.SupplierId, "supplierId");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Discontinued)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("discontinued");
            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .HasColumnName("productName");
            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20)
                .HasColumnName("quantityPerUnit");
            entity.Property(e => e.ReorderLevel).HasColumnName("reorderLevel");
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10)
                .HasColumnName("unitPrice");
            entity.Property(e => e.UnitsInStock).HasColumnName("unitsInStock");
            entity.Property(e => e.UnitsOnOrder).HasColumnName("unitsOnOrder");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("product_ibfk_2");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.ToTable("region");

            entity.Property(e => e.RegionId).HasColumnName("regionId");
            entity.Property(e => e.Regiondescription)
                .HasMaxLength(50)
                .HasColumnName("regiondescription");
        });

        modelBuilder.Entity<Salesorder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.CustId }).HasName("PRIMARY");

            entity.ToTable("salesorder");

            entity.HasIndex(e => e.CustId, "custId");

            entity.HasIndex(e => e.Shipperid, "shipperid");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("orderId");
            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Freight)
                .HasPrecision(10)
                .HasColumnName("freight");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.RequiredDate)
                .HasColumnType("datetime")
                .HasColumnName("requiredDate");
            entity.Property(e => e.ShipAddress)
                .HasMaxLength(60)
                .HasColumnName("shipAddress");
            entity.Property(e => e.ShipCity)
                .HasMaxLength(15)
                .HasColumnName("shipCity");
            entity.Property(e => e.ShipCountry)
                .HasMaxLength(15)
                .HasColumnName("shipCountry");
            entity.Property(e => e.ShipName)
                .HasMaxLength(40)
                .HasColumnName("shipName");
            entity.Property(e => e.ShipPostalCode)
                .HasMaxLength(10)
                .HasColumnName("shipPostalCode");
            entity.Property(e => e.ShipRegion)
                .HasMaxLength(15)
                .HasColumnName("shipRegion");
            entity.Property(e => e.ShippedDate)
                .HasColumnType("datetime")
                .HasColumnName("shippedDate");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");

            entity.HasOne(d => d.Cust).WithMany(p => p.Salesorders)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salesorder_ibfk_2");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Salesorders)
                .HasForeignKey(d => d.Shipperid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salesorder_ibfk_1");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PRIMARY");

            entity.ToTable("shipper");

            entity.Property(e => e.ShipperId).HasColumnName("shipperId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasColumnName("companyName");
            entity.Property(e => e.Phone)
                .HasMaxLength(44)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasColumnName("companyName");
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasColumnName("contactName");
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30)
                .HasColumnName("contactTitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.HomePage).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).HasName("PRIMARY");

            entity.ToTable("territory");

            entity.HasIndex(e => e.RegionId, "regionId");

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("territoryId");
            entity.Property(e => e.RegionId).HasColumnName("regionId");
            entity.Property(e => e.Territorydescription)
                .HasMaxLength(50)
                .HasColumnName("territorydescription");

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("territory_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
