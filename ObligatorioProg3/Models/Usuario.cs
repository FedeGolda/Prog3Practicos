using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        public string Contraseña { get; set; } = null!;

        [Required(ErrorMessage = "El campo Rol es obligatorio.")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

        [ForeignKey("RolId")]
        public virtual Role Rol { get; set; } = null!;
    }
}
