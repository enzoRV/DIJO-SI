using DijoSi.Modelo;
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
    public class UsuarioController : ApiController
    {
        UsuariosNegocios usuariosNegocios = new UsuariosNegocios();

        [HttpPost]
        public string Registra(Usuario user)
        {
            string mensaje = "";
            mensaje = usuariosNegocios.RegistrarUsuarios(user);
            return mensaje;
        }
        [HttpGet]
        public string ValidarCuenta(string codigo)
        {
            string mensaje = "";
            mensaje = usuariosNegocios.VerificarCuenta(codigo);
            return mensaje;

        }
        [HttpPost]
        public Usuario Login(Usuario user)
        {
            return usuariosNegocios.Login(user.loginUsuario, user.passUsuario);
        }

        [HttpGet]
        public List<Usuario> ListarUsuarios()
        {
            return usuariosNegocios.ListarUsuarios();
        }


        [HttpGet]
        public Usuario ObtenerUsuarios(string id)
        {
            var lista = usuariosNegocios.ListarUsuarios();
            Usuario usuario = lista.FirstOrDefault(x => x.idUsuario == id);
            return usuario;
        }

        [HttpPost]
        public string ActualizarUsuarios(Usuario usuario)

        {
            string mensaje = "";
            mensaje = usuariosNegocios.ActualizarUsuarios(usuario);
            return mensaje;
        }



        [HttpDelete]
        public string EliminarUsuarios(string id)
        {
            string mensaje = "";
            mensaje = usuariosNegocios.EliminarUsuarios(id);
            return mensaje;

        }



    }
}
