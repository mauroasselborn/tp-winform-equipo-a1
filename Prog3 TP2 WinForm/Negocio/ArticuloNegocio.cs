using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class ArticuloNegocio
    {


        public List<Articulo> Listar()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> lstArticulo = new List<Articulo>();


            accesoDatos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion,C.Id 'IdCategoria',C.Descripcion 'Categoria',M.Id 'IdMarca',M.Descripcion 'Marca',I.ImagenUrl, A.Precio from ARTICULOS A join CATEGORIAS C on C.Id = A.IdCategoria join MARCAS M on M.Id = A.IdMarca join IMAGENES I on I.IdArticulo = A.Id");

            try
            {
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = Convert.ToInt32(accesoDatos.Lector["Id"]);
                    articulo.Codigo = accesoDatos.Lector["Codigo"].ToString();
                    articulo.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    articulo.Descripcion = accesoDatos.Lector["Descripcion"].ToString();

                    articulo.Marca = new Marca();
                    articulo.Marca.Id = Convert.ToInt32(accesoDatos.Lector["IdMarca"]);
                    articulo.Marca.Descripcion = accesoDatos.Lector["Marca"].ToString();

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = Convert.ToInt32(accesoDatos.Lector["IdCategoria"]);
                    articulo.Categoria.Descripcion = accesoDatos.Lector["Categoria"].ToString();

                    articulo.Imagenes = new Imagen();
                    articulo.Imagenes.ImagenUrl = accesoDatos.Lector["ImagenUrl"].ToString();

                    articulo.Precio = (decimal)accesoDatos.Lector["Precio"];

                    lstArticulo.Add(articulo);
                }
                return lstArticulo;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

        }
        public void Agregar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO Articulos (Codigo,Nombre,Descripcion,Idmarca,IdCategoria,Precio) VALUES ('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Marca.Id + "," + articulo.Categoria.Id + "," + Math.Round(articulo.Precio, 2) + ")");
                accesoDatos.ejecutarAccion();

                AgregarImagen(articulo);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        private void AgregarImagen(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                List<Articulo> lstArticulo = Listar();
                int IdArticulo = lstArticulo.Max(x => x.Id) + 1;
                accesoDatos.setearConsulta("INSERT INTO Imagenes VALUES ('" + IdArticulo + "','" + articulo.Imagenes.ImagenUrl + "')");
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

        public void Modificar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE Articulos SET Codigo = '" + articulo.Codigo + "',Nombre = '" + articulo.Nombre + "',Descripcion = '" + articulo.Descripcion + "' ,Idmarca = " + articulo.Marca.Id + ",IdCategoria =" + articulo.Categoria.Id + " ,Precio =" + articulo.Precio + "where Id = " + articulo.Id + "");
                accesoDatos.ejecutarAccion();

                ActualizarImagen(articulo);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        private void ActualizarImagen(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE Imagenes Set ImagenUrl = '" + articulo.Imagenes.ImagenUrl + "'where IdArticulo = " + articulo.Id + "");
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

        public void EliminarArticulo(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Delete Articulos where Id = " + articulo.Id + "");
                accesoDatos.ejecutarAccion();
                EliminarImagen(articulo.Id);
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
        private void EliminarImagen(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Delete Imagenes where IdArticulo = " + id + "");
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
