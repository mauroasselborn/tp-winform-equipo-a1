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

namespace Prog3_TP2_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DGVArticulos.ColumnCount = 6;
            DGVArticulos.Columns[0].Name = "Codigo";
            DGVArticulos.Columns[1].Name = "Nombre";
            DGVArticulos.Columns[2].Name = "Descripcion";
            DGVArticulos.Columns[3].Name = "Marca";
            DGVArticulos.Columns[4].Name = "Categoria";
            DGVArticulos.Columns[5].Name = "Precio";

            #region Datos que use de prueba
            ArrayList A = new ArrayList();
            A.Add("a");
            A.Add("a");
            A.Add("a");
            A.Add("a");
            A.Add("a");
            A.Add("a");
            DGVArticulos.Rows.Add(A.ToArray());
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