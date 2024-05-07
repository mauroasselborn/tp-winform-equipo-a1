using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class frmEditarCategoria : Form
    {
        private Categoria categoria;
        public frmEditarCategoria()
        {
            InitializeComponent();
        }

        public frmEditarCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (TxtDescripcion.Text.Length != 0)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                try
                {
                   
                    categoriaNegocio.Editar(this.categoria.Id, TxtDescripcion.Text);
                    MessageBox.Show("Editado Correctamente");
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

        private void frmEditarCategoria_Load(object sender, EventArgs e)
        {
            TxtDescripcion.Text = this.categoria.Descripcion.ToString();
        }
    }
}
