using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ObligatorioProg3.Models;

public partial class ObligatorioP3V2Context : DbContext
{
    public ObligatorioP3V2Context()
    {
    }

    public ObligatorioP3V2Context(DbContextOptions<ObligatorioP3V2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Clima> Climas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // => optionsBuilder.UseSqlServer("Data Source=PC-FEDE ;Initial Catalog=ObligatorioP3_V2;Integrated Security=True; TrustServerCertificate=True");
    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FIK9LM4 ;Initial Catalog=ObligatorioP3_V2;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC271AC6334E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TipoCliente).HasMaxLength(50);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Usuarios");
        });

        modelBuilder.Entity<Clima>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clima__3214EC27C10C4462");

            entity.ToTable("Clima");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescripciónClima).HasMaxLength(100);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC2706A8EBED");

            entity.ToTable("Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripción).HasMaxLength(200);
            entity.Property(e => e.NombrePlato).HasMaxLength(100);
            entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Menus)
                .HasForeignKey(d => d.RestauranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Restaurantes");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mesas__3214EC278FFE6E88");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.RestauranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesas_Restaurantes");
        });

        modelBuilder.Entity<OrdenDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenDet__3214EC27BB96C88A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

            entity.HasOne(d => d.Menu).WithMany(p => p.OrdenDetalles)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenDetalles_Menu");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenDetalles)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenDetalles_Ordenes");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordenes__3214EC27EE49C4A7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordenes_Reservas");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagos__3214EC272D5D0E6D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ClimaId).HasColumnName("ClimaID");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Moneda).HasMaxLength(50);
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Clientes");

            entity.HasOne(d => d.Clima).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ClimaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Clima");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Reservas");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permisos__3214EC2733FC6F91");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC273F612301");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaReserva).HasColumnType("datetime");
            entity.Property(e => e.MesaId).HasColumnName("MesaID");
            entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Clientes");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Mesas");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.RestauranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Restaurantes");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reseñas__3214EC271C7166A6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Comentario).HasMaxLength(200);
            entity.Property(e => e.FechaReseña).HasColumnType("datetime");
            entity.Property(e => e.RestauranteId).HasColumnName("RestauranteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reseñas_Clientes");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.RestauranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reseñas_Restaurantes");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Restaura__3214EC279D61D551");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dirección).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Teléfono).HasMaxLength(15);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27939F9563");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27493C0B3F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contraseña).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
