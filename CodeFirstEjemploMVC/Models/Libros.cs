using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEjemploMVC.Models
{
    public class Libros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lid_id { get; set; }
        [Required]
        [StringLength(255)]
        public string Lib_Nombre { get; set; }
        [Required]
        [StringLength(255)]
        public string Lib_Autor { get; set; }
        [Required]
        [StringLength(255)]
        public string Lib_Genero { get; set; }
        [Required]
        [StringLength(255)]
        public string Lib_TipoProyecto { get; set; }
        [Required]
        [StringLength(10)]
        public string Lib_Status { get; set; }
        public ICollection<Personajes> Personajes { get; set; }
    }
}
