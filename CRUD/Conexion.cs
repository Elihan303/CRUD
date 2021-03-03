using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CRUD
{
    class Conexion
    {
        public static SqlConnection Connector() {
            SqlConnection Con = new SqlConnection("SERVER= DESKTOP-PE071QE; DATABASE= REGISTRO; INTEGRATED SECURITY = TRUE;");
            Con.Open();
            return Con;
        }
        SqlConnection Con = new SqlConnection("SERVER= DESKTOP-PE071QE; DATABASE= REGISTRO; INTEGRATED SECURITY = TRUE;");
        
    }
}
