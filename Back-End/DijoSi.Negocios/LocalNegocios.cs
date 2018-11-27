using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijoSi.Modelos;
using DijoSi.Datos;

namespace DijoSi.Negocios
{
    public class LocalNegocios
    {
        LocalDatos data = new LocalDatos();
        
        public List<Local> ListadoLocales()
        {
            return data.ListarLocales();
        }

        public string RegistrarLocales(Local local)
        {
            string mensaje = "";
            try
            {
                data.RegistrarLocales(local);
                mensaje = "Registro exitoso";
            }
            catch(Exception ex)
            {
                mensaje = "No se pudo registrar el local : " + ex.Message;
            }
            return mensaje;

        }

        public string ActualizarLocal(Local local)
        {
            string mensaje = "";
            try
            {
                mensaje = "Registro actualizado";
                data.ActualizarLocal(local);
                //data.ActualizarLocal(local);
                
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                //mensaje = "No se pudo actualizar el local : " + ex.Message;
            }
            return mensaje;
        }

        public string EliminarLocal(string id)
        {
            string mensaje = "";
            try
            {
                mensaje = "Registro eliminado";
                data.EliminarLocal(id);
                
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

       

        public List<Distrito> ListadoDistritos()
        {
            return data.ListarDistritos();
        }
    }
}
