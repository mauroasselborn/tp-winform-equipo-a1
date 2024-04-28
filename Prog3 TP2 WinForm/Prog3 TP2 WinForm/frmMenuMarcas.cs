using System;
using Dominio;
using Negocio;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Prog3_TP2_WinForm
{
    public partial class frmMenuMarcas : Form
    {
        private List<Marca> lstMarca;
        public frmMenuMarcas()
        {
            InitializeComponent();
        }

        private void frmMenuMarcas_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            lstMarca = marcaNegocio.listar();
            dgvListaMarcas.DataSource = lstMarca;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            ABMMarca AbmMarca = new ABMMarca();
            AbmMarca.ShowDialog();
            Cargar();         
        }       

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (dgvListaMarcas.CurrentRow != null)
            {
                Marca marca = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;
                MarcaNegocio marcaNegocio = new MarcaNegocio();

                DialogResult dialogResult = MessageBox.Show("Seguro desea Eliminar?", "Eliminar", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
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
            }
            else
            {
                MessageBox.Show("Seleccione una marca para eliminar");
            }
        }

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            if(dgvListaMarcas.CurrentRow!=null)
            {
                Marca Seleccionado = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;

                ABMMarca AbmMarca = new ABMMarca(Seleccionado);
                AbmMarca.ShowDialog();
                Cargar();
            }
            else
            {
                MessageBox.Show("Seleccione una marca para editar");
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

        private void txtDescripcionMarca_KeyUp(object sender, KeyEventArgs e)
        {
            List<Marca> lstFiltrada = new List<Marca>();

            if (txtDescripcionMarca.Text != "")
            {
                
                lstFiltrada = lstMarca.FindAll(x => x.Descripcion.ToLower().Contains(txtDescripcionMarca.Text.ToLower()));

            }
            else
            {
                lstFiltrada = lstMarca;
            }

            dgvListaMarcas.DataSource = null;
            dgvListaMarcas.DataSource = lstFiltrada;
        }
    }
}
