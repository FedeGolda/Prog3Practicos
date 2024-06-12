using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es requerida")]
    [DataType(DataType.Password)]
    public string Contraseña { get; set; } = null!;
}

