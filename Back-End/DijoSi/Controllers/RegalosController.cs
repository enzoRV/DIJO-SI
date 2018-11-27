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
    public class RegalosController : ApiController
    {
        RegalosNegocios regalosNegocios = new RegalosNegocios();

        [HttpGet]
        public List<Regalo> ListarRegalos()
        {
            return regalosNegocios.ListarRegalos();
        }

        [HttpGet]
        public Regalo ListarRegalosById(string id)
        {
            var lista = regalosNegocios.ListarRegalos();
            Regalo regalo = lista.FirstOrDefault(x => x.idRegalo == id);
            return regalo;
        }

        [HttpPost]
        public string RegistrarRegalos(Regalo regalo)
        {
            string mensaje = "";
            mensaje = regalosNegocios.RegistrarRegalos(regalo);
            return mensaje;
        }

        [HttpDelete]
        public string EliminarRegalos(string id)
        {
            string mensaje = "";

            mensaje = regalosNegocios.EliminarRegalos(id);
            return mensaje;
        }


    }
}
