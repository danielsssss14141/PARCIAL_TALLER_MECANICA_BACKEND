using System;
using System.Collections.Generic;

namespace TALLER_MECANICA.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Primerapellido { get; set; } = null!;

    public string Segundoapellido { get; set; } = null!;

    public long Cedula { get; set; }

    public long Telefono { get; set; }

    public virtual ICollection<Empledo> Empledos { get; set; } = new List<Empledo>();
}
