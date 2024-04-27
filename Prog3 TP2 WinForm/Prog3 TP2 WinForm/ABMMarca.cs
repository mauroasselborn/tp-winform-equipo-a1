using Dominio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Prog3_TP2_WinForm
{
    public partial class ABMMarca : Form
    {
        private Marca marca = null;
        public ABMMarca()
        {
            InitializeComponent();
        }

        public ABMMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
        }

        private void ABMArticulo_Load(object sender, EventArgs e)
        {

            if (marca == null)
            {
                this.Text = "Agregar";
                marca = new Marca();
            }
            else
            {
                this.Text = "Modificar";
                TxtDescripcion.Text = marca.Descripcion;
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (validarForm())
            {
                if (this.marca == null)
                {

                    Marca marca = new Marca();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    try
                    {
                        marca.Descripcion = TxtDescripcion.Text;
                        marcaNegocio.Agregar(marca);
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
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    try
                    {
                        marcaNegocio.Editar(marca.Id, TxtDescripcion.Text);
                        MessageBox.Show("Editado Correctamente");
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                }
            else
            {
                MessageBox.Show("Debe ingresar una descripción");
            }            
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validarForm()
        {
            return TxtDescripcion.Text.Length > 0;
        }
    }
}
