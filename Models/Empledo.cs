using System;
using System.Collections.Generic;

namespace TALLER_MECANICA.Models;

public partial class Empledo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Primerapellido { get; set; } = null!;

    public long TarjetaProfesional { get; set; }

    public long Cedula { get; set; }

    public int Cliente { get; set; }

    public int Vehiculo { get; set; }

    public virtual Cliente ClienteNavigation { get; set; } = null!;

    public virtual Vehiculo VehiculoNavigation { get; set; } = null!;
}
