using DijoSi.Datos;
using DijoSi.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DijoSi.Negocios
{
    public class UsuariosNegocios
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();

        public List<Usuario> ListarUsuarios()
        {
            return usuarioDatos.ListarUsuarios();
        }

        public Usuario Login(string cuenta, string pass)
        {
            return usuarioDatos.Login(cuenta,pass);
        }

        public string RegistrarUsuarios(Usuario usuario)
        {
            string mensaje = "";
            try
            {
              /*  var Existe = CorreoExistente(usuario.emailUsuario);
                if (Existe)
                {
                    mensaje = "Correo ya Registrado";
                }
                else
                {*/
                    usuario.Codigo = Guid.NewGuid();
                    usuario.verificaEmail = false;
                    VerificaviaLink(usuario.emailUsuario, usuario.Codigo.ToString(), "ValidarCuenta");
                    mensaje = "Registrado " + usuario.emailUsuario;
                    usuarioDatos.RegistrarUsuarios(usuario);
              /*  }*/
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
        }

        public List<Usuario> ListarUsuario()
        {
            throw new NotImplementedException();
        }

        public bool CorreoExistente(string email)
        {
            var emails = usuarioDatos.ListarUsuarios();
            Usuario usuario = emails.Where(a => a.emailUsuario == email).FirstOrDefault();
            return emails != null;
        }

        public void VerificaviaLink(string email, string codigo, string correo="")
        {
            string asunto = "";
            string cuerpo = "";
            
            
          //var zelda = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);
            if (correo == "ValidarCuenta")
            {
                var url = "http://localhost:54116/api/Usuario/ValidarCuenta?codigo=" + codigo;
                cuerpo = "Tu cuenta ha sido Existosamente Registrada . Click en el enlace para la verificacion "+
                         url;

                asunto = "Tu Cuenta ha sido Registrada";
            }
            else if (correo == "Recuperar")
            {
                asunto = "Reiniciar Contraseña";

                cuerpo = "Hola tenemos una peticion de reinicio de contraseña . Click aqui para cambiar tu contraseña" /*+
                    "<br/></br><a href=" + zelda + ">Recuperar Cuenta</a>"*/;
            }

            var admin = "dijosienterprise@gmail.com";
            var contra = "bionicle2404";
            var from = new MailAddress(admin, "Dijo Si");
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(from.Address, contra);


            using (var mensaje = new MailMessage(from.Address, email)
            {
                Subject = asunto,
                Body = cuerpo,
            })

            try
            {
                smtp.Send(mensaje);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo enviar ", e.InnerException);
            }
            finally
            {
                smtp.Dispose();
            }


        }

        public string VerificarCuenta(string id)
        {
            string mensaje = "";
            try
            {
                var v = usuarioDatos.ListarUsuarios();
                Usuario usuario = v.Where(a => a.Codigo == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    usuario.verificaEmail = true;
                    usuarioDatos.ActivarCuenta(usuario);
                    mensaje = "Su cuenta ha sido activada";
                }
                else
                {
                    mensaje = "Error";
                }
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return mensaje;
        }


        public string ActualizarUsuarios(Usuario usuario)
        {
            string mensaje = "";
            try
            {
                mensaje = "Usuario actualizado";
                usuarioDatos.ActualizarUsuarios(usuario);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;
            
        }


        public string EliminarUsuarios(string id)
        {
            string mensaje = "";

            try
            {
                mensaje = "Usuario Eliminado";
                usuarioDatos.EliminarUsuarios(id);
            }
            catch (Exception e)
            {
                mensaje = e.Message;

            }
            return mensaje;


        }



    }
    
}
