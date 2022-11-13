using System;
using System.Collections.Generic;

namespace PryAdmin.Models;

public partial class Ejercicio
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Repeticiones { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
