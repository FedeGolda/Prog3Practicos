using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "TipoCliente es obligatorio")]
        [RegularExpression("^(VIP|Frecuente|Nuevo)$", ErrorMessage = "Tiene que ingresar VIP, Frecuente o Nuevo")]
        public string? TipoCliente { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
