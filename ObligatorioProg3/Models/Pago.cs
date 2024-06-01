﻿using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public double Monto { get; set; }

    public DateTime FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}