using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class frmAgregarCategoria : Form
    {

        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (TxtDescripcion.Text.Length != 0)
            {
                Categoria categoria = new Categoria();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                try
                {
                    categoria.Descripcion = TxtDescripcion.Text;
                    categoriaNegocio.Agregar(categoria);
                    MessageBox.Show("Agregado Correctamente");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar contenido");
            }
        }
    }
}
