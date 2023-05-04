using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        //public static ML.Result GetByIdPlantel(int idPlantel)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
        //        {
        //            var semestreList = context.Grupos.FromSqlRaw($"GrupoGetByIdPlantel {idPlantel}").ToList();

        //            result.Objects = new List<object>();

        //            foreach (var row in semestreList)
        //            {
        //                ML.Grupo grupo = new ML.Grupo();

        //                grupo.IdGrupo = row.IdGrupo;
        //                grupo.Nombre = row.Nombre;

        //                result.Objects.Add(grupo);

        //            }

        //            result.Correct = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;

        //    }
        //    return result;
        //}
    }
}
