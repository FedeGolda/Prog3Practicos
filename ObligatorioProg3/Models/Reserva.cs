using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int MesaId { get; set; }

    public int RestauranteId { get; set; }

    public DateTime FechaReserva { get; set; }

    [Required(ErrorMessage = "Estado es obligatorio")]
    [RegularExpression("^(Disponible|Reservada|Ocupada)$", ErrorMessage = "Tiene que ingresar Disponible y Reservada y Ocupada")]
    public string? Estado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Restaurante Restaurante { get; set; } = null!;
}
