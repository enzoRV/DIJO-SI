using DijoSi.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class UsuarioDatos : Conexion
    {
        SqlConnection conexion;

        public UsuarioDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = null;
            string query = "usp_ListarUsuarios";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                usuarios = new List<Usuario>();
                while (rd.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.idUsuario	  = rd["idUsuario"].ToString();
                    usuario.nomUsuario    = rd["nomUsuario"].ToString();
                    usuario.apePatUsuario = rd["apePatUsuario"].ToString();
                    usuario.apeMatUsuario = rd["apeMatUsuario"].ToString();
                    usuario.dniUsuario	  = rd["dniUsuario"].ToString();
                    usuario.telfUsuario	  = rd["telfUsuario"].ToString();
                    usuario.dirUsuario	  = rd["dirUsuario"].ToString();
                    usuario.emailUsuario  = rd["emailUsuario"].ToString();
                    usuario.loginUsuario  = rd["loginUsuario"].ToString();
                    usuario.Codigo        = new Guid(rd["Codigo"].ToString());
                    usuarios.Add(usuario);
                }
            }

            conexion.Close();

            return usuarios;
        }

        public Usuario Login(string cuenta,string pass)
        {
            Usuario login = null;
            string query = "usp_Login";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login", cuenta);
            cmd.Parameters.AddWithValue("@pass", pass);


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                login = new Usuario();
                while (rd.Read())
                {
                    login.idUsuario = rd["idUsuario"].ToString();
                    login.loginUsuario = rd["loginUsuario"].ToString();
                    login.passUsuario = rd["passUsuario"].ToString();
                    login.verificaEmail = bool.Parse(rd["verificaEmail"].ToString());
                }
            }

            conexion.Close();

            return login;

        }

        public void RegistrarUsuarios(Usuario usuario)
        {
            conexion.Open();
            string query = "usp_RegistrarUsuarios";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dniUsuario"    , usuario.dniUsuario);
            cmd.Parameters.AddWithValue("@nomUsuario"    , usuario.nomUsuario);
            cmd.Parameters.AddWithValue("@apePatUsuario" , usuario.apePatUsuario);
            cmd.Parameters.AddWithValue("@apeMatUsuario" , usuario.apeMatUsuario);
            cmd.Parameters.AddWithValue("@telfUsuario"   , usuario.telfUsuario);
            cmd.Parameters.AddWithValue("@dirUsuario"    , usuario.dirUsuario);
            cmd.Parameters.AddWithValue("@emailUsuario"  , usuario.emailUsuario);
            cmd.Parameters.AddWithValue("@loginUsuario"  , usuario.loginUsuario);
            cmd.Parameters.AddWithValue("@passUsuario"   , usuario.passUsuario);
            cmd.Parameters.AddWithValue("@verificaEmail" , usuario.verificaEmail);
            cmd.Parameters.AddWithValue("@Codigo"        , usuario.Codigo);
            cmd.ExecuteNonQuery();
            conexion.Close();
            
        }

        public void ActivarCuenta(Usuario usuario)
        {
            conexion.Open();
            string query = "usp_ActivarUsuarios";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@verificaEmail", usuario.verificaEmail);
            cmd.Parameters.AddWithValue("@id", usuario.idUsuario);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void ActualizarUsuarios(Usuario usuario)

        {
            conexion.Open();
            string query = "usp_ActualizarUsuarios";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
            cmd.Parameters.AddWithValue("@telfUsuario", usuario.telfUsuario);
            cmd.Parameters.AddWithValue("@dirUsuario", usuario.dirUsuario);
            cmd.Parameters.AddWithValue("@emailUsuario", usuario.emailUsuario);
            cmd.Parameters.AddWithValue("@passUsuario", usuario.passUsuario);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }


        public void EliminarUsuarios(string id)
        {

            conexion.Open();
            string query = "usp_EliminarUsuarios";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
