using Microsoft.EntityFrameworkCore;

namespace CodeFirstEjemploMVC.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Personajes> Personajes { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar clave primaria para Personajes
            modelBuilder.Entity<Personajes>().HasKey(p => p.Id);

            // Configurar relaciones
            modelBuilder.Entity<Personajes>()
                .HasOne(p => p.Libro)
                .WithMany(l => l.Personajes)
                .HasForeignKey(p => p.Per_LibId);

            modelBuilder.Entity<Personajes>()
                .HasOne(p => p.Rol)
                .WithMany(r => r.Personajes)
                .HasForeignKey(p => p.Per_RolId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
