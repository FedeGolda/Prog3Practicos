using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pruebaMVC.Models;

public partial class PruebaMvcContext : DbContext
{
    public PruebaMvcContext()
    {
    }

    public PruebaMvcContext(DbContextOptions<PruebaMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FIK9LM4;Initial Catalog=pruebaMVC;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibId).HasName("PK__Libros__4151D0F3F6C6EBA1");

            entity.Property(e => e.LibId).HasColumnName("Lib_Id");
            entity.Property(e => e.LibAutor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Lib_Autor");
            entity.Property(e => e.LibGenero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Lib_Genero");
            entity.Property(e => e.LibNombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Lib_Nombre");
            entity.Property(e => e.LibStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Lib_Status");
            entity.Property(e => e.LibTipoProyecto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Lib_TipoProyecto");
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.PerId).HasName("PK__Personaj__2705F940ADBE602F");

            entity.Property(e => e.PerId).HasColumnName("Per_Id");
            entity.Property(e => e.PerApellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Per_Apellido");
            entity.Property(e => e.PerDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Per_Descripcion");
            entity.Property(e => e.PerFechaNacimiento).HasColumnName("Per_FechaNacimiento");
            entity.Property(e => e.PerLibId).HasColumnName("Per_LibId");
            entity.Property(e => e.PerLugarNacimiento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Per_LugarNacimiento");
            entity.Property(e => e.PerNombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Per_Nombre");
            entity.Property(e => e.PerRolId).HasColumnName("Per_RolId");
            entity.Property(e => e.PerStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Per_Status");

            entity.HasOne(d => d.PerLib).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerLibId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personaje__Per_L__3B75D760");

            entity.HasOne(d => d.PerRol).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personaje__Per_R__3C69FB99");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__795EBD497920D841");

            entity.Property(e => e.RolId).HasColumnName("Rol_Id");
            entity.Property(e => e.RolDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rol_Descripcion");
            entity.Property(e => e.RolStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rol_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
