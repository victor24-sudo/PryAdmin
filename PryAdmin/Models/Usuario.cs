using System;
using System.Collections.Generic;

namespace PryAdmin.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Ejercicio> Ejercicios { get; } = new List<Ejercicio>();
}
