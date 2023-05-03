using Microsoft.AspNetCore.Mvc;

namespace SLWebApi.Controllers
{
    public class SemestreController : Controller
    {
        [HttpGet]
        [Route("api/Semestre/GetAll")]
        public IActionResult GetAll()
        {

            ML.Result result = BL.Semestre.GetAll();

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
