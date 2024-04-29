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
            cmbMarca.DataSource = marcaNegocio.listar();

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
                TxtUrlImg.Text = articulo.Imagenes[0].ImagenUrl;
                CargarImagen(0);

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
                        articulo.Imagenes[0] = new Imagen();
                        articulo.Imagenes[0].ImagenUrl = TxtUrlImg.Text;
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
            if (!(e.KeyChar == ',') && !(e.KeyChar == '.') && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void CargarImagen(int indice)
        {
            try
            {
                PcbArticulo.Load(articulo.Imagenes[indice].ImagenUrl);
                PcbArticulo.Tag = indice;
                TxtUrlImg.Text = articulo.Imagenes[indice].ImagenUrl;
                lblImagen.Text = "Imagen " + ((int)indice + 1) + " de " + articulo.Imagenes.Count;
                if (indice == 0)
                    btnAnterior.Enabled = false;
                else
                    btnAnterior.Enabled = true;
                if (indice < articulo.Imagenes.Count - 1)
                    btnSiguiente.Enabled = true;
                else
                    btnSiguiente.Enabled = false;
            }
            catch (Exception)
            {
                PcbArticulo.Load("https://cdn.vectorstock.com/i/1000v/31/20/image-error-icon-editable-outline-vector-30393120.jpg");
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = false;
                lblImagen.Text = "";
                PcbArticulo.Tag = indice;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (PcbArticulo.Tag != null)
                {
                    if ((int)PcbArticulo.Tag > 0)
                        MessageBox.Show("Por favorcargar una url");
                    {
                        int indice = ((int)PcbArticulo.Tag) - 1;
                        CargarImagen(indice);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Por favorcargar una url");
            }

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (PcbArticulo.Tag != null)
                {
                    if ((int)PcbArticulo.Tag < articulo.Imagenes.Count - 1)
                    {
                        int indice = ((int)PcbArticulo.Tag) + 1;
                        CargarImagen(indice);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Por favorcargar una url");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ABMImagen aBMImagen = new ABMImagen(articulo);
            aBMImagen.ShowDialog();
            if (articulo != null)
            {
                CargarImagen(articulo.Imagenes.Count - 1);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (PcbArticulo.Tag != null)
            {
                ABMImagen aBMImagen = new ABMImagen(articulo, (int)PcbArticulo.Tag);
                aBMImagen.ShowDialog();
                CargarImagen((int)PcbArticulo.Tag);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                if (articulo.Imagenes.Count > 1)
                {
                    articulo.Imagenes.RemoveAt((int)PcbArticulo.Tag);
                    CargarImagen(0);
                    MessageBox.Show("Imagen eliminada. Recuerde guardar el articulo completo para guardar los cambios en las imagenes");
                }
                else
                {
                    MessageBox.Show("El articulo debe tener por lo menos una imagen");
                }
            }

        }
    }
}
