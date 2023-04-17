
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Alumno
    {

        public int IdAlumno { get; set; }
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Solo se permite ingresar letras.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "campo obligatorio")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string NombreCompleto { get; set; }
        public string Imagen { get; set; }
        public ML.Horario Horario { get; set; }

        //public byte IdSemestre { get; set; } //FK

        public ML.Semestre Semestre { get; set; }

        public List<object> Alumnos { get; set; }
    }
}