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
                categoria.Descripcion = txtDescripcion.Text;
                categoriaNegocio.Agregar(categoria);
                Cargar();
                MessageBox.Show("Agregado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());;
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
                    dgvListaCategorias.DataSource = categoriaNegocio.listar();
                    MessageBox.Show("Baja Realizada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); ;
                }
                finally
                {
                    Cargar();
                }
            }
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;

            if (btnEditarCategoria.Text == "Editar")
            {
                txtDescripcion.Text = categoria.Descripcion;
                btnEditarCategoria.Text = "Guardar";
            }
            else
            {
                try
                {
                    if (txtDescripcion.Text.Length > 0)
                    {
                        categoriaNegocio.Editar(categoria.Id, txtDescripcion.Text);
                        dgvListaCategorias.DataSource = categoriaNegocio.listar();
                        MessageBox.Show("Editado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Debe Igresar una Descripcion");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); ;
                }
                finally
                {
                    btnEditarCategoria.Text = "Editar";
                }
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
