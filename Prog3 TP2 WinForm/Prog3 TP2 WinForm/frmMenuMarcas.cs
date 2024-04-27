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
            Cargar();
        }

        private void Cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            dgvListaMarcas.DataSource = marcaNegocio.listar();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            ABMMarca AbmMarca = new ABMMarca();
            AbmMarca.ShowDialog();
            Cargar();         
        }       

        private void btnEliminarMarca_Click(object sender, EventArgs e)
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

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            Marca Seleccionado = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;

            ABMMarca AbmMarca = new ABMMarca(Seleccionado);
            AbmMarca.ShowDialog();
            Cargar();
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
