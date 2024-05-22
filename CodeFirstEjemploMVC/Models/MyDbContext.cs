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
    }
}
