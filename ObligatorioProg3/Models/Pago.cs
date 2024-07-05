using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int ClimaId { get; set; }

    public double Monto { get; set; }

    public DateTime FechaPago { get; set; }

    public string? MetodoPago { get; set; }

    public double? TasaCambio { get; set; }

    public string? Moneda { get; set; }

    public double? MontoConvertido { get; set; }

    public double? PrecioTotal { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Clima Clima { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}
