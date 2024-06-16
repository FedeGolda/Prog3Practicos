﻿using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Resena
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int RestauranteId { get; set; }

    public byte? Puntaje { get; set; }

    public string Comentario { get; set; } = null!;

    public DateTime FechaReseña { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Restaurante Restaurante { get; set; } = null!;
}