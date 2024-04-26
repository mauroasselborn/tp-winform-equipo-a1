using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar(bool soloActivos)
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                string cadenaAux = "";
                //if (soloActivos)
                //    cadenaAux = " WHERE Activo = 1";
                accesoDatos.setearConsulta("SELECT Id, Descripcion FROM marcas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.Id = (int)accesoDatos.Lector["Id"];
                    marca.Descripcion = (string)accesoDatos.Lector["Descripcion"];

                    lista.Add(marca);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void Agregar(Marca nueva)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO MARCAS (Descripcion, Activo) VALUES ('" + nueva.Descripcion + "','1')");
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarLogico(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE MARCAS SET Activo = 0 WHERE Id = " + id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void Editar(int id, string descricion)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE MARCAS SET Descripcion = '" + descricion + "' WHERE Id = " + id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
