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
        [HttpGet]
        [Route("api/Alumno/GetById/{id}")]
        public IActionResult GetById( int id)
        {

            ML.Result result = BL.Alumno.GetByIdEF(id);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPut]
        [Route("api/Alumno/Update/{id}")]
        public IActionResult Update(int id,[FromBody] ML.Alumno alumno)
        {
            //alumno.IdAlumno = id;
            ML.Result result = BL.Alumno.Update(alumno);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
