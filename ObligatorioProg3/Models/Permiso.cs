using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Role> Idrols { get; set; } = new List<Role>();
}
