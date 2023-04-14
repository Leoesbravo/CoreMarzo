using System;
using System.Collections.Generic;

namespace DL;

public partial class Semestre
{
    public byte IdSemestre { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();


}
