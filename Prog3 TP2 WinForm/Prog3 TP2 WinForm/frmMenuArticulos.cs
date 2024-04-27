using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class frmMenuArticulos : Form
    {
        private List<Articulo> lstArticulo;
        public frmMenuArticulos()
        {
            InitializeComponent();
        }

        private void frmMenuArticulos_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaArticulos.CurrentRow != null)
            {
                Articulo Seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                CargarImagen(Seleccionado);
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ABMArticulo AbmArticulo = new ABMArticulo();
            AbmArticulo.ShowDialog();
            Cargar();
        }
        private void Cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            lstArticulo = articuloNegocio.Listar();
            cmbCategoriaArticulo.DataSource = categoriaNegocio.listar();
            cmbMarcaArticulo.DataSource = marcaNegocio.listar();

            cmbMarcaArticulo.DisplayMember = "Descripcion";
            cmbMarcaArticulo.ValueMember = "ID";
            cmbCategoriaArticulo.DisplayMember = "Descripcion";
            cmbCategoriaArticulo.ValueMember = "ID";

            dgvListaArticulos.DataSource = lstArticulo;

            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["Imagenes"].Visible = false;
        }

        private void CargarImagen(Articulo Seleccionado)
        {
            try
            {
                pbxArticulo.Load(Seleccionado.Imagenes.ImagenUrl);

            }
            catch (Exception)
            {
                pbxArticulo.Load("https://cdn.vectorstock.com/i/1000v/31/20/image-error-icon-editable-outline-vector-30393120.jpg");
            }
        }

        private void btnEditarArticulo_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

            ABMArticulo AbmArticulo = new ABMArticulo(Seleccionado);
            AbmArticulo.ShowDialog();
            Cargar();
        }

        private void txtCodigoArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            List<Articulo> lstFiltrada = new List<Articulo>();

            if (txtCodigoArticulo.Text != "")
            {
                lstFiltrada = lstArticulo.FindAll(x => x.Codigo.ToLower().Contains(txtCodigoArticulo.Text.ToLower()));

            }
            else
            {
                lstFiltrada = lstArticulo;
            }

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = lstFiltrada;
            OcultarColumnas();
        }

        private void txtNombreArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            List<Articulo> lstFiltrada = new List<Articulo>();

            if (txtNombreArticulo.Text != "")
            {
                lstFiltrada = lstArticulo.FindAll(x => x.Nombre.ToLower().Contains(txtNombreArticulo.Text.ToLower()));

            }
            else
            {
                lstFiltrada = lstArticulo;
            }

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = lstFiltrada;
            OcultarColumnas();
        }

        private void txtDescripcionArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            List<Articulo> lstFiltrada = new List<Articulo>();

            if (txtDescripcionArticulo.Text != "")
            {
                lstFiltrada = lstArticulo.FindAll(x => x.Descripcion.ToLower().Contains(txtDescripcionArticulo.Text.ToLower()));

            }
            else
            {
                lstFiltrada = lstArticulo;
            }

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = lstFiltrada;
            OcultarColumnas();
        }

        private void TBPrecio_ValueChanged(object sender, EventArgs e)
        {
            List<Articulo> lstFiltrada = new List<Articulo>();
            decimal PrecioMin = lstArticulo.Min(x => x.Precio);
            decimal PrecioMax = lstArticulo.Max(x => x.Precio);

            TBPrecio.Minimum = (int)PrecioMin;
            TBPrecio.Maximum = (int)PrecioMax;

            if (TBPrecio.Value > 0)
            {
                lstFiltrada = lstArticulo.FindAll(x => x.Precio >= TBPrecio.Value);

            }
            else
            {
                lstFiltrada = lstArticulo;
            }

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = lstFiltrada;
            OcultarColumnas();
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                DialogResult dialogResult = MessageBox.Show("Seguro deseas Eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    articuloNegocio.EliminarArticulo(Seleccionado);
                }
                else if (dialogResult == DialogResult.No)
                {
                    Cargar();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar");
            }
            Cargar();
        }


    }
}
