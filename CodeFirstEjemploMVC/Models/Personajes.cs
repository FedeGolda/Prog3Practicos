using System.Data;

namespace CodeFirstEjemploMVC.Models
{
    public class Personajes
    {
        public int Per_LibId { get; set; }
        public int Per_RolId { get; set; }
        public Libros Libro { get; set; }
        public Roles Rol { get; set; }
    }
}
