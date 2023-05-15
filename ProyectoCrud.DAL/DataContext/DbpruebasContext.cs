using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Models;

namespace ProyectoCrud.DAL.DataContext;

public partial class DbpruebasContext : DbContext
{
    public DbpruebasContext()
    {
    }

    public DbpruebasContext(DbContextOptions<DbpruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.ToTable("contacto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nacimiento)
                .HasColumnType("date")
                .HasColumnName("nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Registro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registro");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
