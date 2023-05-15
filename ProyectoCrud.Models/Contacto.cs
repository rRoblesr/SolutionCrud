using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Contacto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public DateTime? Nacimiento { get; set; }

    public DateTime? Registro { get; set; }
}
