using DijoSi.Datos;
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class FotografoNegocios
    {
        FotografoDatos fotografoDatos = new FotografoDatos();

        public List<Fotografo> ListarFotografos()
        {
            return fotografoDatos.ListarFotografos();
        }

        public string RegistrarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            try
            {
                mensaje = "Fotografo registrado";
                fotografoDatos.RegistrarFotografos(fotografo);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string ActualizarFotografos(Fotografo fotografo)
        {
            string mensaje = "";
            try
            {
                mensaje = "Fotografo actualizado";
                fotografoDatos.ActualizarFotografos(fotografo);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string EliminarFotografos(string id)
        {
            string mensaje = "";
            try
            {
                mensaje = "Fotografo Eliminado";
                fotografoDatos.EliminarFotografos(id);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
