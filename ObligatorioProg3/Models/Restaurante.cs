using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Restaurante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Telefono { get; set; }

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();
}
