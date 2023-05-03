using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {
             return "Data Source=.;Initial Catalog=IEspinozaProgramacionNCapasGM2023;Persist Security Info=True;User ID=sa;Password=pass@word1";
        }
        //como acceder a un app setting en .net core 
       
    }
}
