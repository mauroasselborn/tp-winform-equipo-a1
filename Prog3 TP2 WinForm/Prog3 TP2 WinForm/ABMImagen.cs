using Dominio;
using System;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class ABMImagen : Form
    {
        private Articulo _articulo;
        private int _indice = -1;
        public ABMImagen(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
        }

        public ABMImagen(Articulo articulo, int indice)
        {
            InitializeComponent();
            _articulo = articulo;
            _indice = indice;
        }

        private void TxtUrlImg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PcbArticulo.Load(TxtUrlImg.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("URL no válida");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_indice == -1)
            {
                Imagen imagen = new Imagen();
                if (TxtUrlImg.Text != "")
                {
                    imagen.IdArticulo = _articulo.Id;
                    imagen.ImagenUrl = TxtUrlImg.Text;
                    _articulo.Imagenes.Add(imagen);
                    MessageBox.Show("Imagen agregada. Recuerde guardar el articulo completo para guardar los cambios en las imagenes");
                    Close();
                }
            }
            else
            {
                _articulo.Imagenes[_indice].ImagenUrl = TxtUrlImg.Text;
                MessageBox.Show("Imagen modificada. Recuerde guardar el articulo completo para guardar los cambios en las imagenes");
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
