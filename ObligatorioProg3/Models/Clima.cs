using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Clima
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public short Temperatura { get; set; }

    public string DescripcionClima { get; set; } = null!;
}
