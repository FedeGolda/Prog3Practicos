using System;
using System.Collections.Generic;

namespace Práctica8EjerciciosDeAccesoADatos.Models;

public partial class Pelicula
{
    public long Id { get; set; }

    public string? Titulo { get; set; }

    public int? Anio { get; set; }

    public int? Calificacion { get; set; }

    public virtual ICollection<Copia> Copia { get; set; } = new List<Copia>();
}
