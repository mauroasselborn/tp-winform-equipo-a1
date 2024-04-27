using System;
using Dominio;
using Negocio;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class frmMenuMarcas : Form
    {
        public frmMenuMarcas()
        {
            InitializeComponent();
        }

        private void frmMenuMarcas_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            dgvListaMarcas.DataSource = marcaNegocio.listar();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if(validarForm())
            {
                Marca marca = new Marca();
                MarcaNegocio marcaNegocio = new MarcaNegocio();

                try
                {
                    marca.Descripcion = txtDescripcionMarca.Text;
                    marcaNegocio.Agregar(marca);
                    dgvListaMarcas.DataSource = marcaNegocio.listar();
                    limpiarForm();
                    MessageBox.Show("Agregado Correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar una descripción");
            }            
        }       

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            Marca marca = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                marcaNegocio.Eliminar(marca.Id);
                dgvListaMarcas.DataSource = marcaNegocio.listar();
                limpiarForm();
                MessageBox.Show("Baja Realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;

            if (btnEditarMarca.Text == "Editar")
            {
                txtDescripcionMarca.Text = marca.Descripcion;
                btnEditarMarca.Text = "Guardar";
            }
            else
            {
                try
                {
                    if (validarForm())
                    {
                        marcaNegocio.Editar(marca.Id, txtDescripcionMarca.Text);
                        dgvListaMarcas.DataSource = marcaNegocio.listar();
                        limpiarForm();
                        MessageBox.Show("Editado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar una descripcion");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnEditarMarca.Text = "Editar";
                }
            }
        }

        public bool validarForm()
        {
            return txtDescripcionMarca.Text.Length > 0;
        }

        public void limpiarForm()
        {
            txtDescripcionMarca.ResetText();
        }
    }
}
