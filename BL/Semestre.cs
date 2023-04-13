using Microsoft.EntityFrameworkCore;
namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    var semestreList = context.Semestres.FromSqlRaw("SemestreGetAll").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in semestreList)
                    {
                        ML.Semestre semestre = new ML.Semestre();

                        semestre.IdSemestre = row.IdSemestre;
                        semestre.Nombre = row.Nombre;

                        semestre.Alumno = new ML.Alumno();
                        semestre.Alumno.Nombre = row.NombreAlumno;

                        result.Objects.Add(semestre);

                    }

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public  static ML.Result Add(ML.Semestre semestre)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"SemestreAdd '{semestre.Nombre}'");
                    //int queryEF = context.Database.ExecuteSqlRaw($"SemestreAdd '{semestre.Nombre}', {semestre.IdSemestre} ");
                    

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
    }
}