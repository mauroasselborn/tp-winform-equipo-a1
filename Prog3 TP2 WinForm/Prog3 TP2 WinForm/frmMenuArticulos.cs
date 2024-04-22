using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class frmMenuArticulos : Form
    {
        public frmMenuArticulos()
        {
            InitializeComponent();
        }

        private void frmMenuArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            dgvListaArticulos.DataSource = articuloNegocio.Listar();
        }
    }
}
