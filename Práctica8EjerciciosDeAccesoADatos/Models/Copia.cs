using System;
using System.Collections.Generic;

namespace Práctica8EjerciciosDeAccesoADatos.Models;

public partial class Copia
{
    public long Id { get; set; }

    public long? IdPelicula { get; set; }

    public bool? Deteriorada { get; set; }

    public string? Formato { get; set; }

    public double? PrecioAlquiler { get; set; }

    public virtual ICollection<Alquilere> Alquileres { get; set; } = new List<Alquilere>();

    public virtual Pelicula? IdPeliculaNavigation { get; set; }
}
