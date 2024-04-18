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

        private void altaBajaOModificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMDeArticulos form = new frmABMDeArticulos();
            form.MdiParent = this;
            form.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoDeArticulos form = new frmListadoDeArticulos();
            form.MdiParent = this;
            form.Show();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMDeCategorias form = new frmABMDeCategorias();
            form.MdiParent = this;
            form.Show();
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListadoDeCategorias form = new frmListadoDeCategorias();
            form.MdiParent = this;
            form.Show();
        }

        private void aBMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmABMDeMarcas form = new frmABMDeMarcas();
            form.MdiParent = this;
            form.Show();
        }

        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListadoDeMarcas form = new frmListadoDeMarcas();
            form.MdiParent = this;
            form.Show();
        }
    }
}
