﻿using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class OrdenDetalle
{
    public int Id { get; set; }

    public int OrdenId { get; set; }

    public int MenuId { get; set; }

    public short Cantidad { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Ordene Orden { get; set; } = null!;
}