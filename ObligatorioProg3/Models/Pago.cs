using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int ClimaId { get; set; }

    public double Monto { get; set; }

    public DateTime FechaPago { get; set; }

    [Required(ErrorMessage = "MetodoPago es obligatorio")]
    [RegularExpression("^(Efectivo|Tarjeta)$", ErrorMessage = "Tiene que ingresar Efectivo o Tarjeta")]
    public string? MetodoPago { get; set; }

    public double? TasaCambio { get; set; }

    [Required(ErrorMessage = "Moneda es obligatorio")]
    [RegularExpression("^(Pesos|USD)$", ErrorMessage = "Tiene que ingresar Pesos o USD")]
    public string? Moneda { get; set; }

    public double? MontoConvertido { get; set; }

    public double? PrecioTotal { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Clima Clima { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}
