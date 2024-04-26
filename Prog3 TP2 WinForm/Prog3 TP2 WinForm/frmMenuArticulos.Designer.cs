
namespace Prog3_TP2_WinForm
{
    partial class frmMenuArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBPrecio = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarArticulo = new System.Windows.Forms.Button();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.cmbCategoriaArticulo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMarcaArticulo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.Location = new System.Drawing.Point(275, 12);
            this.dgvListaArticulos.MultiSelect = false;
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.ReadOnly = true;
            this.dgvListaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaArticulos.Size = new System.Drawing.Size(646, 622);
            this.dgvListaArticulos.TabIndex = 0;
            this.dgvListaArticulos.SelectionChanged += new System.EventHandler(this.dgvListaArticulos_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TBPrecio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEditarArticulo);
            this.panel1.Controls.Add(this.btnEliminarArticulo);
            this.panel1.Controls.Add(this.btnAgregarArticulo);
            this.panel1.Controls.Add(this.cmbCategoriaArticulo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbMarcaArticulo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescripcionArticulo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNombreArticulo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCodigoArticulo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 363);
            this.panel1.TabIndex = 5;
            // 
            // TBPrecio
            // 
            this.TBPrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TBPrecio.Location = new System.Drawing.Point(6, 250);
            this.TBPrecio.Name = "TBPrecio";
            this.TBPrecio.Size = new System.Drawing.Size(232, 45);
            this.TBPrecio.TabIndex = 11;
            this.TBPrecio.ValueChanged += new System.EventHandler(this.TBPrecio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Precio";
            // 
            // btnEditarArticulo
            // 
            this.btnEditarArticulo.Location = new System.Drawing.Point(175, 316);
            this.btnEditarArticulo.Name = "btnEditarArticulo";
            this.btnEditarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btnEditarArticulo.TabIndex = 7;
            this.btnEditarArticulo.Text = "Editar";
            this.btnEditarArticulo.UseVisualStyleBackColor = true;
            this.btnEditarArticulo.Click += new System.EventHandler(this.btnEditarArticulo_Click);
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Location = new System.Drawing.Point(88, 316);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarArticulo.TabIndex = 6;
            this.btnEliminarArticulo.Text = "Eliminar";
            this.btnEliminarArticulo.UseVisualStyleBackColor = true;
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(2, 316);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarArticulo.TabIndex = 5;
            this.btnAgregarArticulo.Text = "Agregar";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // cmbCategoriaArticulo
            // 
            this.cmbCategoriaArticulo.FormattingEnabled = true;
            this.cmbCategoriaArticulo.Location = new System.Drawing.Point(67, 203);
            this.cmbCategoriaArticulo.Name = "cmbCategoriaArticulo";
            this.cmbCategoriaArticulo.Size = new System.Drawing.Size(171, 21);
            this.cmbCategoriaArticulo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Categoría";
            // 
            // cmbMarcaArticulo
            // 
            this.cmbMarcaArticulo.FormattingEnabled = true;
            this.cmbMarcaArticulo.Location = new System.Drawing.Point(67, 176);
            this.cmbMarcaArticulo.Name = "cmbMarcaArticulo";
            this.cmbMarcaArticulo.Size = new System.Drawing.Size(171, 21);
            this.cmbMarcaArticulo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Marca";
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(67, 147);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(171, 20);
            this.txtDescripcionArticulo.TabIndex = 2;
            this.txtDescripcionArticulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcionArticulo_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descripción";
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Location = new System.Drawing.Point(67, 121);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(171, 20);
            this.txtNombreArticulo.TabIndex = 1;
            this.txtNombreArticulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombreArticulo_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(67, 95);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(171, 20);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoArticulo_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Filtros";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.ErrorImage = global::Prog3_TP2_WinForm.Properties.Resources.imgMenuPrincipal;
            this.pbxArticulo.Image = global::Prog3_TP2_WinForm.Properties.Resources.imgMenuPrincipal;
            this.pbxArticulo.InitialImage = null;
            this.pbxArticulo.Location = new System.Drawing.Point(12, 12);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(254, 253);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 2;
            this.pbxArticulo.TabStop = false;
            // 
            // frmMenuArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvListaArticulos);
            this.Controls.Add(this.pbxArticulo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(947, 683);
            this.MinimumSize = new System.Drawing.Size(947, 683);
            this.Name = "frmMenuArticulos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos";
            this.Load += new System.EventHandler(this.frmMenuArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCategoriaArticulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMarcaArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionArticulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditarArticulo;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TBPrecio;
    }
}