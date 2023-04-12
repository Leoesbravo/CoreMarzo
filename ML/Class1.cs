namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string NombreCompleto { get; set; }
        public string Imagen { get; set; }
        //public ML.Horario Horario { get; set; }

        //public byte IdSemestre { get; set; } //FK

        public ML.Semestre Semestre { get; set; }

        public List<object> Alumnos { get; set; }
    }
}