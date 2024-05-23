using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEjemploMVC.Models
{
    public class Personajes
    {
        [Key]
        public int Id { get; set; } // Clave primaria

        [ForeignKey("Libro")]
        public int Per_LibId { get; set; }
        [ForeignKey("Rol")]
        public int Per_RolId { get; set; }

        public Libros Libro { get; set; }
        public Roles Rol { get; set; }
    }
}
