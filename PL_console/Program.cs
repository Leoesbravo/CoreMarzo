ReadFile();
Console.ReadKey();


static void ReadFile()
{
    string file = @"C:\Users\digis\Desktop\CargaMasivatxt.txt";
    

    if (File.Exists(file))
    {

        StreamReader Textfile = new StreamReader(file);

        string line;
        line = Textfile.ReadLine();
        while ((line = Textfile.ReadLine()) != null)
        {
            string[] lines = line.Split(",");

            ML.Alumno alumno = new ML.Alumno();

            alumno.Nombre = lines[0];
            alumno.ApellidoPaterno = lines[1];
            alumno.ApellidoMaterno = lines[2];
            alumno.FechaNacimiento = lines[3];
            alumno.Semestre = new ML.Semestre();

            alumno.Semestre.IdSemestre = byte.Parse(lines[4]);

            alumno.Horario = new ML.Horario();
            alumno.Horario.Turno = lines[5];

            alumno.Horario.Grupo = new ML.Grupo();
            alumno.Horario.Grupo.IdGrupo = int.Parse(lines[6]);

            alumno.Imagen = "";

            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Se inserto el registro");
                Console.ReadKey();
            }
            else
            {
                string fileError = @"C: \Users\digis\Desktop\Errores.txt";
                StreamWriter errorFile = new StreamWriter(fileError);
                //CREAR UN TXT DE ERRORES

            }

        }
    }
}