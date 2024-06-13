using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;


namespace ObligatorioProg3.Models;

public partial class ObligatorioP3Context : DbContext
{
    public ObligatorioP3Context()
    {
    }

    public ObligatorioP3Context(DbContextOptions<ObligatorioP3Context> options)
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

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=PC-FEDE ;Initial Catalog=ObligatorioP3;Integrated Security=True; TrustServerCertificate=True");
      // => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FIK9LM4 ;Initial Catalog=ObligatorioP3;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3213E83F3DF824C4");

            entity.ToTable("clientes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(50)
                .HasColumnName("tipoCliente");
        });

        modelBuilder.Entity<Clima>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clima__3213E83F1D35E94E");

            entity.ToTable("clima");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionClima)
                .HasMaxLength(50)
                .HasColumnName("descripcionClima");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Temperatura).HasColumnName("temperatura");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83F46665369");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombrePlato)
                .HasMaxLength(25)
                .HasColumnName("nombrePlato");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mesas__3213E83F977731C7");

            entity.ToTable("mesas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.NumeroMesa).HasColumnName("numeroMesa");
        });

        modelBuilder.Entity<OrdenDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ordenDet__3213E83F43293B6A");

            entity.ToTable("ordenDetalles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.MenuId).HasColumnName("menuId");
            entity.Property(e => e.OrdenId).HasColumnName("ordenId");

            entity.HasOne(d => d.Menu).WithMany(p => p.OrdenDetalles)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ordenDeta__menuI__5EBF139D");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenDetalles)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ordenDeta__orden__5DCAEF64");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ordenes__3213E83F988951BA");

            entity.ToTable("ordenes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReservaId).HasColumnName("reservaId");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ordenes__reserva__59063A47");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pagos__3213E83FC7218386");

            entity.ToTable("pagos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("fechaPago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(25)
                .HasColumnName("metodoPago");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.ReservaId).HasColumnName("reservaId");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pagos__reservaId__5FB337D6");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservas__3213E83FA03A32A7");

            entity.ToTable("reservas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .HasColumnName("estado");
            entity.Property(e => e.FechaReserva)
                .HasColumnType("datetime")
                .HasColumnName("fechaReserva");
            entity.Property(e => e.MesaId).HasColumnName("mesaId");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservas__client__4CA06362");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservas__mesaId__4D94879B");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reseñas__3213E83F0E292C98");

            entity.ToTable("reseñas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(100)
                .HasColumnName("comentarios");
            entity.Property(e => e.FechaReseña)
                .HasColumnType("datetime")
                .HasColumnName("fechaReseña");
            entity.Property(e => e.Puntaje).HasColumnName("puntaje");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reseñas__Cliente__60A75C0F");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.RestauranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reseñas__Restaur__619B8048");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83F1A48CD82");

            entity.ToTable("restaurantes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F093BD308");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
