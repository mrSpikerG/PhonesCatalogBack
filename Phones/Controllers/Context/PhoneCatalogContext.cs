using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Phones.Models.Database;

namespace Phones.Controllers.Context;

public partial class PhoneCatalogContext : DbContext
{
    public PhoneCatalogContext()
    {
    }

    public PhoneCatalogContext(DbContextOptions<PhoneCatalogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2I5L44I\\SQLEXPRESS;Initial Catalog=PhoneCatalog;Integrated security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PK__Phone__F3EE4BB05E258382");

            entity.ToTable("Phone");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.PriceType)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
