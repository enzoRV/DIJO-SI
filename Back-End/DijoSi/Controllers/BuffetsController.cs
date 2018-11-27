using DijoSi.Modelos;
using DijoSi.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DijoSi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BuffetsController : ApiController
    {
        BuffetsNegocios buffetsNegocios = new BuffetsNegocios();

        [HttpGet]
        public List<Buffet> ListarBuffets()
        {
            return buffetsNegocios.ListarBuffets();
        }

        [HttpGet]
        public List<Categoria> ListarCategorias()
        {
            return buffetsNegocios.ListarCategorias();
        }

        [HttpPost]
        public string RegistrarBuffets(Buffet buffet)
        {
            string mensaje = "";
            mensaje = buffetsNegocios.RegistrarBuffets(buffet);
            return mensaje;
        }

        [HttpDelete]
        public string EliminarBuffets(string id)
        {
            string mensaje = "";
            mensaje = buffetsNegocios.EliminarBuffets(id);
            return mensaje;
        }

        [HttpPost]
        public string ActualizarBuffets(Buffet buffet)
        {
            string mensaje = "";
            mensaje = buffetsNegocios.ActualizarBuffet(buffet);
            return mensaje;
        }

        [HttpGet]
        public Buffet ObtenerBuffets(string id)
        {
            var lista = buffetsNegocios.ListarBuffets();
            Buffet buffet = lista.FirstOrDefault(x => x.idBuffet == id);
            return buffet;
        }



    }
}
