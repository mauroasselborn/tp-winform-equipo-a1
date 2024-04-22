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


            accesoDatos.SetearQuery("select A.Codigo, A.Nombre, A.Descripcion,C.Descripcion as 'Categoria',M.Descripcion as 'Marca',I.ImagenUrl, A.Precio from ARTICULOS A join CATEGORIAS C on C.Id = A.IdCategoria join MARCAS M on M.Id = A.IdMarca join IMAGENES I on I.IdArticulo = A.Id");

            try
            {
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Codigo = accesoDatos.Lector["Codigo"].ToString();
                    articulo.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    articulo.Descripcion = accesoDatos.Lector["Descripcion"].ToString();

                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = accesoDatos.Lector["Marca"].ToString();

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = accesoDatos.Lector["Categoria"].ToString();
                    articulo.Precio =(decimal)accesoDatos.Lector["Precio"];

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
                accesoDatos.CerrarConexion();
            }

        }
    }
}
