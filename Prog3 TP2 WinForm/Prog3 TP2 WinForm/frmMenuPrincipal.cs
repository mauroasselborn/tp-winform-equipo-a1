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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuArticulos frmMenuArticulos = new frmMenuArticulos();
            frmMenuArticulos.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuCategorias frmMenuCategorias = new frmMenuCategorias();
            frmMenuCategorias.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmMenuMarcas frmMenuMarcas = new frmMenuMarcas();
            frmMenuMarcas.ShowDialog();
        }
    }
}
