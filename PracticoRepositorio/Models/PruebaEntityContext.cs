using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticoRepositorio.Models;

public partial class PruebaEntityContext : DbContext
{
    public PruebaEntityContext()
    {
    }

    public PruebaEntityContext(DbContextOptions<PruebaEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=PC-FEDE ;Initial Catalog=PruebaEntity;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3213E83F8C4DF99F");

            entity.ToTable("Curso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_curso");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3213E83F9D845652");

            entity.ToTable("Estudiante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Estudiant__id_cu__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
