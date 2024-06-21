using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Clima
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public double Temperatura { get; set; }

    public string DescripciónClima { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
