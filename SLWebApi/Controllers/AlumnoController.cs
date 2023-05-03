using Microsoft.AspNetCore.Mvc;

namespace SLWebApi.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        [Route("api/Alumno/GetAll")]
        public IActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll(alumno);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Alumno/Add")]
        public IActionResult Add([FromBody] ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
