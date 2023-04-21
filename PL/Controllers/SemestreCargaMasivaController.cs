using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PL.Controllers
{
    public class SemestreCargaMasivaController : Controller
    {

        private IHostingEnvironment environment;
        private IConfiguration configuration;
        public SemestreCargaMasivaController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            environment = _environment;
            configuration = _configuration;
        }

        [HttpGet]
        public IActionResult CargaMasiva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CargaMasiva(ML.Semestre semestre)
        {
            IFormFile file = Request.Form.Files["fileExcel"];

            if (file != null)
            {
                //.xsls , .xls, .csv
                //obtener el nombre de nuestro archivo
                string fileName = Path.GetFileName(file.FileName);

                string folderPath = configuration["PathFolder"];
                string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                string extensionAppsettings = configuration["TipoExcel"];
                if (extensionArchivo == extensionAppsettings)
                {
                    //crear una copia del archivo cargado
                }
                else
                {
                    ViewBag.Message = "El archivo que se intenta procesar no es un excel";
                }

            }
            return View();
        }
    }
}
