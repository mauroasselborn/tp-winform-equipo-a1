using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> lstArticulo = new List<Articulo>();


            accesoDatos.setearConsulta("select A.Codigo, A.Nombre, A.Descripcion,C.Id 'IdCategoria',C.Descripcion 'Categoria',M.Id 'IdMarca',M.Descripcion 'Marca',I.ImagenUrl, A.Precio from ARTICULOS A join CATEGORIAS C on C.Id = A.IdCategoria join MARCAS M on M.Id = A.IdMarca join IMAGENES I on I.IdArticulo = A.Id");

            try
            {
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
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
    }
}
