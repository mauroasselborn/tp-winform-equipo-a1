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
        private SqlConnection conexion;
        private SqlCommand comando { get; set; }
        private SqlDataReader lector { get; set; }

        public SqlDataReader Lector {
            get {return lector; } 
        }

        AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void SetearQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }
        public void EjecutarLectura(){
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteReader();
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
