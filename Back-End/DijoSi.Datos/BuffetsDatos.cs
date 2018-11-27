
using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class BuffetsDatos : Conexion
    {

        SqlConnection conexion;

        public BuffetsDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

        public List<Buffet> ListarBuffets()
        {
            List<Buffet> buffets = null;
            string query = "usp_ListarBuffets";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                buffets = new List<Buffet>();
                while (rd.Read())
                {
                    Buffet buffet = new Buffet();
                    buffet.idBuffet = rd["idBuffet"].ToString();
                    buffet.nomprovBuffet = rd["nomprovBuffet"].ToString();
                    buffet.nomBuffet = rd["nomBuffet"].ToString();
                    buffet.desBuffet = rd["desBuffet"].ToString();
                    buffet.preBuffet = (decimal)rd["preBuffet"];
                    buffet.idCategoria = rd["idCategoria"].ToString();
                    buffet.nomCategoria = rd["nomCategoria"].ToString();
                    buffets.Add(buffet);
                }
            }

            conexion.Close();

            return buffets;
        }

        public void ActualizarBuffets(Buffet buffet)
        {
            conexion.Open();
            string query = "usp_ActualizarBuffets";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBuffet", buffet.idBuffet);
            cmd.Parameters.AddWithValue("@preBuffet", buffet.preBuffet);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarBuffets(string id)
        {
            conexion.Open();
            string query = "usp_EliminarBuffets";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBuffet", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void RegistrarBuffets(Buffet buffet)
        {
            string query = "usp_RegistrarBuffets";
            conexion.Open();
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomprovBuffet", buffet.nomprovBuffet);
            cmd.Parameters.AddWithValue("@nomBuffet", buffet.nomBuffet);
            cmd.Parameters.AddWithValue("@desBuffet", buffet.desBuffet);
            cmd.Parameters.AddWithValue("@preBuffet", buffet.preBuffet);
            cmd.Parameters.AddWithValue("@idCategoria", buffet.idCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Categoria> ListarCategoria()
        {
            List<Categoria> categorias = null;
            string query = "select * from tb_categoria";

            SqlCommand cmd = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                categorias = new List<Categoria>();
                while (rd.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.idCategoria = rd["idCategoria"].ToString();
                    categoria.nomCategoria = rd["nomCategoria"].ToString();
                    categorias.Add(categoria);
                }
            }

            conexion.Close();

            return categorias;
        }

    }
}
