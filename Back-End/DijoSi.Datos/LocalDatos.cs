using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DijoSi.Modelos;

namespace DijoSi.Datos
{
    public class LocalDatos : Conexion
    {

        SqlConnection con;

        public LocalDatos()
        {
            con = new SqlConnection(conexionString);
        }

        public void ActualizarLocal(Local local)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("usp_ActualizarLocales", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", local.idLocal);
            cmd.Parameters.AddWithValue("@nom", local.nomLocal);
            cmd.Parameters.AddWithValue("@dir", local.dirLocal);
            cmd.Parameters.AddWithValue("@fONo", local.telfLocal);
            cmd.Parameters.AddWithValue("@cant", local.cantLocal);
            cmd.Parameters.AddWithValue("@iddis", local.idDistrito);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        public void RegistrarLocales(Local local)
        {
                
                con.Open();

                SqlCommand cmd = new SqlCommand("usp_RegistrarLocales", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", local.nomLocal);
                cmd.Parameters.AddWithValue("@dir", local.dirLocal);
                cmd.Parameters.AddWithValue("@fono", local.telfLocal);
                cmd.Parameters.AddWithValue("@cant", local.cantLocal);
                cmd.Parameters.AddWithValue("@iddis", local.idDistrito);
                
                cmd.ExecuteNonQuery();
           
                con.Close(); 
            
        }

        public void EliminarLocal(string id)
        {

            con.Open();
            string query = "usp_EliminarLocales";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();

            con.Close();
        }

        public List<Local> ListarLocales()
        {
            con.Open();
            List<Local> locales = new List<Local>();
            string query = "usp_ListarLocales";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Local local = new Local();
                    local.idLocal = dr["idLocal"].ToString();
                    local.nomLocal = dr["nomLocal"].ToString();
                    local.dirLocal = dr["dirLocal"].ToString();
                    local.telfLocal = dr["telfLocal"].ToString();
                    local.cantLocal = (Int32)dr["cantLocal"];
                    local.idDistrito = dr["idDistrito"].ToString();
                    local.nomDistrito = dr["nomDistrito"].ToString();
                    locales.Add(local);
                }
            }
            
            dr.Close();
            con.Close();
            return locales;

        }
        public List<Distrito> ListarDistritos()
        {
            con.Open();
            List<Distrito> distritos = new List<Distrito>();
            SqlCommand cmd = new SqlCommand("usp_ListarDistritos", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distrito distrito = new Distrito();
                distrito.idDistrito = dr["idDistrito"].ToString();
                distrito.nomDistrito = dr["nomDistrito"].ToString();
                distritos.Add(distrito);
            }
            dr.Close();
            con.Close();
            return distritos;

        }

    }
}
