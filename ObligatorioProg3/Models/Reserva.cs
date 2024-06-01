﻿using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public DateTime FechaReserva { get; set; }

    public string Estado { get; set; } = null!;

    public int ClienteId { get; set; }

    public int MesaId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}