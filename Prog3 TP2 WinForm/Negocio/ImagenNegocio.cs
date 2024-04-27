using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = (int)accesoDatos.Lector["Id"];
                    imagen.IdArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    imagen.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];
                    lista.Add(imagen);
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

        public List<Imagen> listar(int IdArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo="+IdArticulo);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = (int)accesoDatos.Lector["Id"];
                    imagen.IdArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    imagen.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];
                    lista.Add(imagen);
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

        public void Agregar(Imagen nueva)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (" + nueva.IdArticulo + ",'"+nueva.ImagenUrl+"')");
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
                accesoDatos.setearConsulta("DELETE FROM IMAGENES WHERE Id = " + id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar");
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void Editar(Imagen imagen)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE IMAGENES SET IdArticulo ="+imagen.IdArticulo+", ImagenUrl='" + imagen.ImagenUrl + "' WHERE Id = " + imagen.Id);
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
    }
}
