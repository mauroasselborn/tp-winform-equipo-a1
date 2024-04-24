using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
           Articulo Seleccionado = (Articulo) dgvListaArticulos.CurrentRow.DataBoundItem;
            
            try
            {
                pbxArticulo.Load(Seleccionado.Imagenes.ImagenUrl);
                
            }
            catch (Exception )
            {
                pbxArticulo.Load("https://cdn.vectorstock.com/i/1000v/31/20/image-error-icon-editable-outline-vector-30393120.jpg");
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

            lstArticulo = articuloNegocio.Listar();
            dgvListaArticulos.DataSource = lstArticulo;
            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["Imagenes"].Visible = false;
        }

        private void btnEditarArticulo_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
            
            ABMArticulo AbmArticulo = new ABMArticulo(Seleccionado);
            AbmArticulo.ShowDialog();
            Cargar();
        }
    }
}
