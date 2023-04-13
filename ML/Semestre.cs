using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Semestre
    {
        public byte IdSemestre { get; set; }
        public string Nombre { get; set; }
        public List<object> Semestres { get; set; }
        public ML.Alumno Alumno { get; set; }
        //public Semestres { get; set; }

    }
}
