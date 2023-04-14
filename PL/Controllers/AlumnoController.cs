using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();


            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
            }

            return View(alumno);
        }
        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            ML.Result resultSemestres = BL.Semestre.GetAll();
            ML.Result resultPlanteles = BL.Plantel.GetAll();

            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();

            alumno.Horario = new ML.Horario();
            alumno.Horario.Grupo = new ML.Grupo();
            alumno.Horario.Grupo.Plantel = new ML.Plantel();

            if (resultSemestres.Correct)
            {
                alumno.Semestre.Semestres = resultSemestres.Objects;
                alumno.Horario.Grupo.Plantel.Planteles = resultPlanteles.Objects;
            }
            //add o update
            if (idAlumno == null)
            {
                //add
                //mostrar formulario vacio
                return View(alumno);
            }

            else
            {
                //bl.alumno.getbyid(idAlumno.value)
                //ML.Result result = BL.Alumno.GetByIdEF(idAlumno.Value);

                if (alumno != null)
                {
                    //    //update
                    //    //muestra el formulario con la informacion del alumno
                    //    alumno = (ML.Alumno)result.Object;


                    //    ML.Result resultGrupos = BL.Grupo.GetByIdPlantel(alumno.Horario.Grupo.Plantel.IdPlantel);

                    //    //ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(alumno.Direccion.Colonia.Municipio.Estado.IdEstado);

                    //    alumno.Horario.Grupo.Grupos = resultGrupos.Objects;
                    //    alumno.Semestre.Semestres = resultSemestres.Objects;
                    //    alumno.Horario.Grupo.Plantel.Planteles = resultPlanteles.Objects;
                    //    //alumno.Direccion.Colonia.Municipio.Municipio = resultMunicipios.Objects;

                    //    return View(alumno);
                    return View();

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta del alumno ";
                    return View("Modal");
                }


            }
        }
        [HttpPost] //va a recibir la informacion que venga desde la vista  
        public ActionResult Form(ML.Alumno alumno)
        {
            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                alumno.Imagen = Convert.ToBase64String(ConvertToBytes(file));

            }

            ML.Result result = new ML.Result();
            //add o update
            if (alumno.IdAlumno == 0)
            {
                //add
                result = BL.Alumno.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el alumno" + result.ErrorMessage;
                }

            }
            else
            {

                //update
                //result = BL.Alumno.UpdateEF(alumno);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "Se actualizo correctamente el registro del alumno";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error al actualizar el registro del alumno" + result.ErrorMessage;
                //}
            }

            return View("Modal");
        }

        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        public JsonResult GetGrupo(int idPlantel)
        {
            var result = BL.Grupo.GetByIdPlantel(idPlantel);

            return Json(result.Objects);
        }

    }
}
