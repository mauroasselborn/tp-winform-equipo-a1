using System;
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
            frmArticulos frmArticulos = new frmArticulos();
            frmArticulos.ShowDialog();
        }
    }
}
