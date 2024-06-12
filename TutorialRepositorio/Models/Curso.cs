using System;
using System.Collections.Generic;

namespace TutorialRepositorio.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string? NombreCurso { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
