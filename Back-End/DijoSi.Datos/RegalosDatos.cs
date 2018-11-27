using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class RegalosDatos : Conexion
    {
        SqlConnection conexion;

        public RegalosDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public void RegistrarRegalos(Regalo regalo)
        {
            conexion.Open();
            string query = "usp_RegistrarRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desRegalo", regalo.desRegalo);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Regalo> ListarRegalos()
        {
            List<Regalo> regalos = null;
            string query = "usp_ListarRegalos";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                regalos = new List<Regalo>();
                while (rd.Read())
                {
                    Regalo regalo = new Regalo();
                    regalo.idRegalo = rd["idRegalo"].ToString();
                    regalo.desRegalo = rd["desRegalo"].ToString();
                    regalos.Add(regalo);
                }
            }

            conexion.Close();

            return regalos;
        }

        public void EliminarRegalos(string id)
        {
            conexion.Open();
            string query = "usp_EliminarRegalo";


            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRegalo", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
