using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Prog3_TP2_WinForm
{
    public partial class frmListadoDeArticulos : Form
    {
        public frmListadoDeArticulos()
        {
            InitializeComponent();
        }

        private void frmListadoDeArticulos_Load(object sender, EventArgs e)
        {
            #region Datos que use de prueba
           List<Articulo> lstproducto = new List<Articulo>();
           Articulo producto = new Articulo();

            producto.Codigo = 123;
            producto.Nombre = "A";
            lstproducto.Add(producto);

            DGVArticulos.DataSource = lstproducto;
            #endregion

            DataGridViewButtonColumn btnDetalle = new DataGridViewButtonColumn();
            btnDetalle.Text= "Detalles";
            btnDetalle.UseColumnTextForButtonValue = true;
            DGVArticulos.Columns.Add(btnDetalle);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            DGVArticulos.Columns.Add(btnEliminar);


        }

        private void DGVArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                MessageBox.Show("Detalle");
            }
            if (e.ColumnIndex == 7)
            {
                MessageBox.Show("Eliminar");
            }
        }
    }
}