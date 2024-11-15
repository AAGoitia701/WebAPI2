using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI2.Models;

public partial class DbTestContext : DbContext
{
    public DbTestContext()
    {
    }

    public DbTestContext(DbContextOptions<DbTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MainUser> MainUsers { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MainUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__MainUser__B7C92638C3D98E02");

            entity.ToTable("MainUser");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__2E8946D48CE40652");

            entity.ToTable("Product");

            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
