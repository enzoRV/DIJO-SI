using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DijoSi.Datos
{
    public class Conexion
    {
        protected string conexionString { get; set; }

        public Conexion()
        {
            conexionString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        }
    }
}
