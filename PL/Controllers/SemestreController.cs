using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class SemestreController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Semestre.GetAll();

            ML.Semestre semestre = new ML.Semestre();
            semestre.Semestres = result.Objects;

            return View(semestre);
        }
        [HttpGet]
        public ActionResult Form()
        {
            //ML.Result resultArea = BL.Area.GetAll();

            //ML.Departamento departamento = new ML.Departamento();

            //departamento.Area = new ML.Area();
            //departamento.Area.Areas = resultArea.Objects;

            //return View(departamento);
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Semestre semestre)
        {
            ML.Result result = BL.Semestre.Add(semestre);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha insertado el semestre";
            }
            else
            {
                ViewBag.Message = "Se ha insertado el semestre";
            }
            return PartialView("Modal");
        }
    }
}
