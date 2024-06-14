using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public int RolId { get; set; }

    public string TipoPermisos { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;
}
