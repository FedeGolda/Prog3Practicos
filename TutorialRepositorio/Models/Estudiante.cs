using System;
using System.Collections.Generic;

namespace TutorialRepositorio.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public int? IdCurso { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }
}
