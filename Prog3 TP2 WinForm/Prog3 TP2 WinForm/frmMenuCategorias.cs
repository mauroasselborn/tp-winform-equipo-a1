using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace Prog3_TP2_WinForm
{
    public partial class frmMenuCategorias : Form
    {
        public frmMenuCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                categoria.Descripcion = txtDescripcionCategoria.Text;
                categoriaNegocio.Agregar(categoria);
                dgvListaCategorias.DataSource = categoriaNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());;
            }
        }

        private void frmMenuCategorias_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            dgvListaCategorias.DataSource = categoriaNegocio.listar();
            dgvListaCategorias.Columns["Activo"].Visible = false;
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            
            try
            {
                categoriaNegocio.Eliminar(categoria.Id);
                dgvListaCategorias.DataSource = categoriaNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
        }
    }
}
