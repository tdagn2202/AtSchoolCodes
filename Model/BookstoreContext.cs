using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookUI.Model;

public partial class BookstoreContext : DbContext
{
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookstore> Bookstores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=bookstore;uid=root;pwd=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookstore>(entity =>
        {
            entity.HasKey(e => e.BookNo).HasName("PRIMARY");

            entity.ToTable("bookstore");

            entity.Property(e => e.BookNo).HasColumnName("bookNo");
            entity.Property(e => e.BookName)
                .HasMaxLength(100)
                .HasColumnName("bookName");
            entity.Property(e => e.Publisher)
                .HasMaxLength(200)
                .HasColumnName("publisher");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
