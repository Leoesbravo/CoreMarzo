using System;
using System.Collections.Generic;

namespace DL;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public byte? IdSemestre { get; set; }

    public string? Imagen { get; set; }

    public bool? Estatus { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Semestre? IdSemestreNavigation { get; set; }

    //Propiedades creaadas 

    public string SemestreNombre { get; set; }
    public string Turno { get; set; }
    public int IdGrupo { get; set; }
    public string Grupo { get; set; }
    public int IdPlantel { get; set; }
    public string Plantel { get; set; }
}
