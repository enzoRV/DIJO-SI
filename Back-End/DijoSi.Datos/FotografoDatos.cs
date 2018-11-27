using DijoSi.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Datos
{
    public class FotografoDatos : Conexion
    {
        SqlConnection conexion;

        public FotografoDatos()
        {
            conexion = new SqlConnection(conexionString);
        }

            public void RegistrarFotografos(Fotografo fotografo)
            {

                string query = "usp_RegistrarFotografo";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NomFotografo", fotografo.nomFotografo);
                cmd.Parameters.AddWithValue("@telfFotografo", fotografo.telfFotografo);
                cmd.Parameters.AddWithValue("@dirFotografo", fotografo.dirFotografo);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }

            public void EliminarFotografos(string id)
            {
                conexion.Open();
                string query = "usp_EliminarFotografo";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFotografo", id);

            cmd.ExecuteNonQuery();
                conexion.Close();
            }

            public void ActualizarFotografos(Fotografo fotografo)
            {
                conexion.Open();
                string query = "usp_ActualizarFotografo";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFotografo", fotografo.idFotografo);
                cmd.Parameters.AddWithValue("@telfFotografo", fotografo.telfFotografo);
                cmd.Parameters.AddWithValue("@dirFotografo", fotografo.dirFotografo);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }

            public List<Fotografo> ListarFotografos()
            {
                List<Fotografo> fotografos = null;
                string query = "usp_ListarFotografos";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    fotografos = new List<Fotografo>();
                    while (rd.Read())
                    {
                        Fotografo fotografo = new Fotografo();
                        fotografo.idFotografo = rd["idFotografo"].ToString();
                        fotografo.nomFotografo = rd["nomFotografo"].ToString();
                        fotografo.telfFotografo = rd["telfFotografo"].ToString();
                        fotografo.dirFotografo = rd["dirFotografo"].ToString();
                        fotografos.Add(fotografo);
                    }
                }

                conexion.Close();

                return fotografos;

            }
        
    }
}

