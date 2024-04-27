using Dominio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class ABMArticulo : Form
    {
        private Articulo articulo = null;
        public ABMArticulo()
        {
            InitializeComponent();
        }

        public ABMArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void ABMArticulo_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cmbMarca.DisplayMember = "Descripcion";
            cmbMarca.ValueMember = "ID";
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "ID";

            cmbCategoria.DataSource = categoriaNegocio.listar();
            cmbMarca.DataSource = marcaNegocio.listar(true);

            if (articulo == null)
            {

                this.Text = "Agregar";
                Articulo articulo = new Articulo();
            }
            else
            {
                this.Text = "Modificar";
                TxtCodigo.Text = articulo.Codigo;
                TxtNombre.Text = articulo.Nombre;
                TxtDescripcion.Text = articulo.Descripcion;
                TxtPrecio.Text = articulo.Precio.ToString();
                TxtUrlImg.Text = articulo.Imagenes.ImagenUrl;
                try
                {
                    PcbArticulo.Load(articulo.Imagenes.ImagenUrl);

                }
                catch (Exception)
                {
                    PcbArticulo.Load("https://cdn.vectorstock.com/i/1000v/31/20/image-error-icon-editable-outline-vector-30393120.jpg");
                }

                cmbCategoria.SelectedValue = articulo.Categoria.Id;
                cmbMarca.SelectedValue = articulo.Marca.Id;
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (this.articulo == null)
                {
                    Articulo articulo = new Articulo();

                    articulo.Codigo = TxtCodigo.Text;
                    articulo.Nombre = TxtNombre.Text;
                    articulo.Descripcion = TxtDescripcion.Text;
                    if (TxtPrecio.Text != "")
                        articulo.Precio = Convert.ToDecimal(TxtPrecio.Text);

                    if (TxtUrlImg.Text != "")
                    {
                        articulo.Imagenes = new Imagen();
                        articulo.Imagenes.ImagenUrl = TxtUrlImg.Text;
                    }

                    articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    articulo.Marca = (Marca)cmbMarca.SelectedItem;

                    if (ValidarTodo())
                    {
                        articuloNegocio.Agregar(articulo);

                        MessageBox.Show("Realizado correctamente!");
                        Close();
                    }


                }
                else
                {
                    articulo.Codigo = TxtCodigo.Text;
                    articulo.Nombre = TxtNombre.Text;
                    articulo.Descripcion = TxtDescripcion.Text;

                    if (TxtPrecio.Text != "")
                        articulo.Precio = Convert.ToDecimal(TxtPrecio.Text);
                    if (TxtUrlImg.Text != "")
                    {
                        articulo.Imagenes = new Imagen();
                        articulo.Imagenes.ImagenUrl = TxtUrlImg.Text;
                    }
                    articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    articulo.Marca = (Marca)cmbMarca.SelectedItem;
                    if (ValidarTodo())
                    {
                        articuloNegocio.Modificar(articulo);

                        MessageBox.Show("Realizado correctamente!");
                        Close();
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error de carga");
            }
        }

        private bool ValidarTodo()
        {
            if (TxtCodigo.Text == "" || TxtNombre.Text == "" ||
                TxtDescripcion.Text == "" || TxtUrlImg.Text == "" ||
                TxtPrecio.Text == "")
            {
                MessageBox.Show("Por favor completar todos los campos");
                return false;
            }
            return true;
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void CargarImagen(string URL)
        {
            try
            {
                PcbArticulo.Load(URL);

            }
            catch (Exception)
            {
                PcbArticulo.Load("https://cdn.vectorstock.com/i/1000v/31/20/image-error-icon-editable-outline-vector-30393120.jpg");
            }
        }

        private void TxtUrlImg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarImagen(TxtUrlImg.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Por favor utilice un link valido");
            }
        }
    }
}
