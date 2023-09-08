using System;
using System.Collections.Generic;

namespace TALLER_MECANICA.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public string Color { get; set; } = null!;

    public DateTime FechaTecno { get; set; }

    public DateTime FechaSoat { get; set; }

    public virtual ICollection<Empledo> Empledos { get; set; } = new List<Empledo>();
}
