using DijoSi.Modelos;
using DijoSi.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Negocios
{
    public class BuffetsNegocios
    {
        BuffetsDatos buffetsDatos = new BuffetsDatos();

        public List<Buffet> ListarBuffets()
        {
            return buffetsDatos.ListarBuffets();
        }

        public List<Categoria> ListarCategorias()
        {
            return buffetsDatos.ListarCategoria();
        }

        public string RegistrarBuffets(Buffet buffet)
        {
            string mensaje = "";
            try
            {
                mensaje = "Buffet registrado";
                buffetsDatos.RegistrarBuffets(buffet);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string EliminarBuffets(string id)
        {
            string mensaje = "";
            try
            {
                mensaje = "Buffet Eliminado";
                buffetsDatos.EliminarBuffets(id);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public string ActualizarBuffet(Buffet buffet)
        {
            string mensaje = "";

            try
            {
                mensaje = "Buffet actualizado";
                buffetsDatos.ActualizarBuffets(buffet);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }
    }
}
