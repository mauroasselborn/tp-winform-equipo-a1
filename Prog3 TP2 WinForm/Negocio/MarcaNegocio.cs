using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
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
            catch (Exception)
            {
                throw new Exception("Error al obtener el listado");
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
                accesoDatos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES ('" + nueva.Descripcion + "')");
                accesoDatos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw new Exception("Error al guardar");
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if(validarEliminación(id))
                {
                    accesoDatos.setearConsulta("DELETE FROM MARCAS WHERE Id = " + id);
                    accesoDatos.ejecutarAccion();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar. Pruebe a eliminar o modificar los articulos relacionados");
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
            catch (Exception)
            {

                throw new Exception("Error al editar");
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public bool validarEliminación(int id)
        {            
            AccesoDatos accesoDatos = new AccesoDatos();
            bool result = false;

            try
            {
                accesoDatos.setearConsulta("SELECT Count(Id) C FROM ARTICULOS WHERE IdMarca="+id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    result = !((int)accesoDatos.Lector["C"] > 0);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                accesoDatos.cerrarConexion();                
            }

            return result;
        }
    }
}
