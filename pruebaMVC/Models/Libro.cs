using System;
using System.Collections.Generic;

namespace pruebaMVC.Models;

public partial class Libro
{
    public int LibId { get; set; }

    public string? LibNombre { get; set; }

    public string? LibAutor { get; set; }

    public string? LibGenero { get; set; }

    public string? LibTipoProyecto { get; set; }

    public string? LibStatus { get; set; }

    public virtual ICollection<Personaje> Personajes { get; set; } = new List<Personaje>();
}
