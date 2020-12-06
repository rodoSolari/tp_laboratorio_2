namespace Solari.Rodolfo._2A.TP4
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewLibros = new System.Windows.Forms.DataGridView();
            this.BtnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.BtnAgregarNuevoLibro = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.richTextBoxFactura = new System.Windows.Forms.RichTextBox();
            this.btnRealizarCompra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pictureBoxImagenes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLibros
            // 
            this.dataGridViewLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibros.Location = new System.Drawing.Point(33, 175);
            this.dataGridViewLibros.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewLibros.Name = "dataGridViewLibros";
            this.dataGridViewLibros.Size = new System.Drawing.Size(820, 390);
            this.dataGridViewLibros.TabIndex = 0;
            // 
            // BtnAgregarAlCarrito
            // 
            this.BtnAgregarAlCarrito.BackColor = System.Drawing.Color.GreenYellow;
            this.BtnAgregarAlCarrito.Location = new System.Drawing.Point(577, 104);
            this.BtnAgregarAlCarrito.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregarAlCarrito.Name = "BtnAgregarAlCarrito";
            this.BtnAgregarAlCarrito.Size = new System.Drawing.Size(144, 43);
            this.BtnAgregarAlCarrito.TabIndex = 4;
            this.BtnAgregarAlCarrito.Text = "Agregar al carrito";
            this.BtnAgregarAlCarrito.UseVisualStyleBackColor = false;
            this.BtnAgregarAlCarrito.Click += new System.EventHandler(this.BtnAgregarAlCarrito_Click);
            // 
            // BtnAgregarNuevoLibro
            // 
            this.BtnAgregarNuevoLibro.BackColor = System.Drawing.Color.GreenYellow;
            this.BtnAgregarNuevoLibro.Location = new System.Drawing.Point(97, 104);
            this.BtnAgregarNuevoLibro.Name = "BtnAgregarNuevoLibro";
            this.BtnAgregarNuevoLibro.Size = new System.Drawing.Size(144, 43);
            this.BtnAgregarNuevoLibro.TabIndex = 11;
            this.BtnAgregarNuevoLibro.Text = "Agregar nuevo libro";
            this.BtnAgregarNuevoLibro.UseVisualStyleBackColor = false;
            this.BtnAgregarNuevoLibro.Click += new System.EventHandler(this.BtnAgregarNuevoLibro_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.GreenYellow;
            this.btnEliminar.Location = new System.Drawing.Point(258, 104);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(137, 43);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar libro";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.GreenYellow;
            this.btnModificar.Location = new System.Drawing.Point(416, 104);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(142, 43);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar libro";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSalir.Location = new System.Drawing.Point(1021, 522);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(196, 43);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // richTextBoxFactura
            // 
            this.richTextBoxFactura.Location = new System.Drawing.Point(884, 227);
            this.richTextBoxFactura.Name = "richTextBoxFactura";
            this.richTextBoxFactura.Size = new System.Drawing.Size(522, 265);
            this.richTextBoxFactura.TabIndex = 17;
            this.richTextBoxFactura.Text = "";
            // 
            // btnRealizarCompra
            // 
            this.btnRealizarCompra.BackColor = System.Drawing.Color.GreenYellow;
            this.btnRealizarCompra.Location = new System.Drawing.Point(970, 151);
            this.btnRealizarCompra.Name = "btnRealizarCompra";
            this.btnRealizarCompra.Size = new System.Drawing.Size(161, 70);
            this.btnRealizarCompra.TabIndex = 16;
            this.btnRealizarCompra.Text = "Realizar compra ";
            this.btnRealizarCompra.UseVisualStyleBackColor = false;
            this.btnRealizarCompra.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(640, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Libreria de idiomas";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Chartreuse;
            this.btnLimpiar.Location = new System.Drawing.Point(1175, 153);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(154, 68);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Deshacer cambios";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pictureBoxImagenes
            // 
            this.pictureBoxImagenes.Location = new System.Drawing.Point(1248, 5);
            this.pictureBoxImagenes.Name = "pictureBoxImagenes";
            this.pictureBoxImagenes.Size = new System.Drawing.Size(248, 142);
            this.pictureBoxImagenes.TabIndex = 20;
            this.pictureBoxImagenes.TabStop = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1509, 623);
            this.Controls.Add(this.pictureBoxImagenes);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxFactura);
            this.Controls.Add(this.btnRealizarCompra);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.BtnAgregarNuevoLibro);
            this.Controls.Add(this.BtnAgregarAlCarrito);
            this.Controls.Add(this.dataGridViewLibros);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libreria de idiomas";
            this.Load += new System.EventHandler(this.FormLibros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLibros;
        private System.Windows.Forms.Button BtnAgregarAlCarrito;
        private System.Windows.Forms.Button BtnAgregarNuevoLibro;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RichTextBox richTextBoxFactura;
        private System.Windows.Forms.Button btnRealizarCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.PictureBox pictureBoxImagenes;
    }
}

