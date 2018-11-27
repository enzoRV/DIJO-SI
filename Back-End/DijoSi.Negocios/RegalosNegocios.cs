using DijoSi.Datos;
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class RegalosNegocios
    {
        RegalosDatos regalosDatos = new RegalosDatos();

        public List<Regalo> ListarRegalos()
        {
            return regalosDatos.ListarRegalos();
        }

        public string RegistrarRegalos(Regalo regalo)
        {
            string mensaje = "";
            try
            {
                mensaje = "Regalo registrado";
                regalosDatos.RegistrarRegalos(regalo);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string EliminarRegalos(string id)
        {
            string mensaje = "";
            try
            {
                mensaje = "Regalo Eliminado";
                regalosDatos.EliminarRegalos(id);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
