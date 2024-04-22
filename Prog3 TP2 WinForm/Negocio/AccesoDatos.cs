using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class AccesoDatos
    {
        private SqlConnection conexion { get; set; }
        private SqlCommand comando { get; set; }
        private SqlDataReader lector { get; set; }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("data source=.\\sqlexpress; initial catalog=CATALOGO_P3_DB; integrated security=sspi");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void SetearQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }

        public void EjecutarLectura()
        {
            try
            {
                conexion.Open();
                lector =comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void CerrarConexion()
        {
            if (lector != null)
                conexion.Close();
            conexion.Close();
        }
    }
}
