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
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            accesoDatos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion,C.Id 'IdCategoria',C.Descripcion 'Categoria',M.Id 'IdMarca',M.Descripcion 'Marca',A.Precio from ARTICULOS A join CATEGORIAS C on C.Id = A.IdCategoria join MARCAS M on M.Id = A.IdMarca");

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

                    articulo.Imagenes = new List<Imagen>();
                    articulo.Imagenes = imagenNegocio.listar(articulo.Id);

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

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                foreach (Imagen imagen in articulo.Imagenes)
                {
                    imagenNegocio.Agregar(imagen);
                }

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

        public void Modificar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE Articulos SET Codigo = '" + articulo.Codigo + "',Nombre = '" + articulo.Nombre + "',Descripcion = '" + articulo.Descripcion + "' ,Idmarca = " + articulo.Marca.Id + ",IdCategoria =" + articulo.Categoria.Id + " ,Precio =" + articulo.Precio + "where Id = " + articulo.Id + "");
                accesoDatos.ejecutarAccion();

                ImagenNegocio imagenNegocio = new ImagenNegocio();

                List<Imagen> imagenesViejas = imagenNegocio.listar(articulo.Id);
                foreach (Imagen imagenvieja in imagenesViejas)
                {
                    if(!articulo.Imagenes.Any(X=>X.Id==imagenvieja.Id))
                    {
                        imagenNegocio.Eliminar(imagenvieja.Id);
                    }
                }

                foreach (Imagen imagen in articulo.Imagenes)
                {
                    if(imagen.Id==0)
                        imagenNegocio.Agregar(imagen);
                    else
                        imagenNegocio.Editar(imagen);
                }
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

        public void EliminarArticulo(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Delete Articulos where Id = " + articulo.Id + "");
                accesoDatos.ejecutarAccion();

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                foreach (Imagen imagen in articulo.Imagenes)
                {
                    imagenNegocio.Eliminar(imagen.Id);
                }
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
