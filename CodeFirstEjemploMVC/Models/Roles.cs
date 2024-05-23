using System.ComponentModel.DataAnnotations;

namespace CodeFirstEjemploMVC.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; } // Clave primaria

        public ICollection<Personajes> Personajes { get; set; }
    }
}
