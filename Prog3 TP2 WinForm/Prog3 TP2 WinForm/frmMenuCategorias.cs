using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Prog3_TP2_WinForm
{
    public partial class frmMenuCategorias : Form
    {
        private List<Categoria> listCategorias;
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
                if (txtDescripcion.Text != "")
                {
                    categoria.Descripcion = txtDescripcion.Text;
                    categoriaNegocio.Agregar(categoria);
                    txtDescripcion.Text = "";
                    Cargar();
                    MessageBox.Show("Agregado Correctamente");
                }
                else
                {
                    MessageBox.Show("Ingresar datos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
        }

        private void frmMenuCategorias_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            listCategorias = categoriaNegocio.listar();
            dgvListaCategorias.DataSource = listCategorias;
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            DialogResult dialogResult = MessageBox.Show("Seguro desea Eliminar?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    categoriaNegocio.Eliminar(categoria.Id);
                    Cargar();
                    MessageBox.Show("Baja Realizada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); ;
                }
            }
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvListaCategorias.CurrentRow != null)
            {
                Categoria Seleccion = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;

                frmEditarCategoria editar = new frmEditarCategoria(Seleccion);
                editar.ShowDialog();
                Cargar();
            }
            else
            {
                MessageBox.Show("Seleccione una marca para editar");
            }
        }


        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            List<Categoria> lstFiltrada = new List<Categoria>();

            if (txtFiltro.Text != "")
            {
                lstFiltrada = listCategorias.FindAll(x => x.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower()));

            }
            else
            {
                lstFiltrada = listCategorias;
            }

            dgvListaCategorias.DataSource = null;
            dgvListaCategorias.DataSource = lstFiltrada;
        }
    }
}
