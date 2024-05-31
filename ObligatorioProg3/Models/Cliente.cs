using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    [RegularExpression("^(Nuevo|Frecuente|VIP)$", ErrorMessage = "El TipoCliente tiene que ser Nuevo, Frecuente o VIP.")]
    public string TipoCliente { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();
}
