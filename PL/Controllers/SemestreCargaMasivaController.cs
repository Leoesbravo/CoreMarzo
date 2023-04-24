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
            ML.Result result = new ML.Result();

            return View(result);
        }

        [HttpPost]
        public IActionResult CargaMasiva(ML.Semestre semestre)
        {
            IFormFile file = Request.Form.Files["fileExcel"];

            if (HttpContext.Session.GetString("PathArchivo") == null)
            {
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
                        string filePath = Path.Combine(environment.ContentRootPath, folderPath, Path.GetFileNameWithoutExtension(fileName)) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                        if (!System.IO.File.Exists(filePath))
                        {
                            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            string connString = configuration["ExcelConString"] + filePath;//cadena de conexion y ruta especifica del archivo

                            //crear un metodo en BL.Semestre
                            ML.Result resultExcelDt = BL.Semestre.ConvertExcelToDataTable(connString);

                            if (resultExcelDt.Correct)
                            {
                                ML.Result resultValidacion = BL.Semestre.ValidarExcel(resultExcelDt.Objects);

                                if (resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    HttpContext.Session.SetString("PathArchivo", filePath);
                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Message = "El excel no contiene registros";
                            }
                        }

                    }
                    else
                    {
                        ViewBag.Message = "El archivo que se intenta procesar no es un excel";
                    }

                }
            }
            else
            {
                string rutaArchivoExcel = HttpContext.Session.GetString("PathArchivo");
                string connectionString = configuration["ConnectionStringExcel:value"] + rutaArchivoExcel;

                ML.Result resultData = BL.Semestre.ConvertExcelToDataTable(connectionString);
                if (resultData.Correct)
                {
                    ML.Result resultErrores = new ML.Result();
                    resultErrores.Objects = new List<object>();

                    foreach (ML.Semestre semestreItem in resultData.Objects)
                    {

                        ML.Result resultAdd = BL.Semestre.Add(semestreItem);
                        if (!resultAdd.Correct)
                        {
                            resultErrores.Objects.Add("No se insertó el Semestre con nombre: " + semestreItem.Nombre + " Error: " + resultAdd.ErrorMessage);
                        }
                    }
                    if (resultErrores.Objects.Count > 0)
                    {

                        string fileError = Path.Combine(environment.WebRootPath, @"~\Files\logErrores.txt");
                        using (StreamWriter writer = new StreamWriter(fileError))
                        {
                            foreach (string ln in resultErrores.Objects)
                            {
                                writer.WriteLine(ln);
                            }
                        }
                        ViewBag.Message = "Las Alumnos No han sido registrados correctamente";
                    }
                    else
                    {
                        //borrar session
                        ViewBag.Message = "Las Alumnos han sido registrados correctamente";
                    }

                }

            }
            return PartialView("Modal");
        }
    }
}
