namespace Solari.Rodolfo._2A.TP4
{
    partial class FormVenta
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
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCupon = new System.Windows.Forms.Label();
            this.lblmporteAPagar = new System.Windows.Forms.Label();
            this.lbImporte = new System.Windows.Forms.Label();
            this.checkBoxEfectivo = new System.Windows.Forms.CheckBox();
            this.cmbCantidad = new System.Windows.Forms.ComboBox();
            this.lbNombreLibro = new System.Windows.Forms.Label();
            this.lbPrecioLibro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLibro
            // 
            this.lblLibro.AutoSize = true;
            this.lblLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibro.Location = new System.Drawing.Point(50, 40);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(47, 16);
            this.lblLibro.TabIndex = 4;
            this.lblLibro.Text = "Libro:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(50, 89);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 16);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(235, 89);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(74, 16);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(54, 237);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(153, 43);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(276, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 43);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCupon
            // 
            this.lblCupon.AutoSize = true;
            this.lblCupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCupon.Location = new System.Drawing.Point(51, 138);
            this.lblCupon.Name = "lblCupon";
            this.lblCupon.Size = new System.Drawing.Size(176, 16);
            this.lblCupon.TabIndex = 9;
            this.lblCupon.Text = "Paga en efectivo (10 %):";
            // 
            // lblmporteAPagar
            // 
            this.lblmporteAPagar.AutoSize = true;
            this.lblmporteAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmporteAPagar.Location = new System.Drawing.Point(54, 176);
            this.lblmporteAPagar.Name = "lblmporteAPagar";
            this.lblmporteAPagar.Size = new System.Drawing.Size(122, 16);
            this.lblmporteAPagar.TabIndex = 17;
            this.lblmporteAPagar.Text = "Importe a pagar:";
            // 
            // lbImporte
            // 
            this.lbImporte.AutoSize = true;
            this.lbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImporte.Location = new System.Drawing.Point(201, 176);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Size = new System.Drawing.Size(51, 16);
            this.lbImporte.TabIndex = 18;
            this.lbImporte.Text = "label8";
            // 
            // checkBoxEfectivo
            // 
            this.checkBoxEfectivo.AutoSize = true;
            this.checkBoxEfectivo.Location = new System.Drawing.Point(233, 140);
            this.checkBoxEfectivo.Name = "checkBoxEfectivo";
            this.checkBoxEfectivo.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEfectivo.TabIndex = 21;
            this.checkBoxEfectivo.UseVisualStyleBackColor = true;
            this.checkBoxEfectivo.CheckedChanged += new System.EventHandler(this.checkBoxEfectivo_CheckedChanged);
            // 
            // cmbCantidad
            // 
            this.cmbCantidad.FormattingEnabled = true;
            this.cmbCantidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbCantidad.Location = new System.Drawing.Point(324, 85);
            this.cmbCantidad.Name = "cmbCantidad";
            this.cmbCantidad.Size = new System.Drawing.Size(54, 21);
            this.cmbCantidad.TabIndex = 22;
            this.cmbCantidad.Text = "1";
            this.cmbCantidad.SelectedIndexChanged += new System.EventHandler(this.cmbCantidad_SelectedIndexChanged);
            // 
            // lbNombreLibro
            // 
            this.lbNombreLibro.AutoSize = true;
            this.lbNombreLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreLibro.Location = new System.Drawing.Point(133, 42);
            this.lbNombreLibro.Name = "lbNombreLibro";
            this.lbNombreLibro.Size = new System.Drawing.Size(63, 16);
            this.lbNombreLibro.TabIndex = 23;
            this.lbNombreLibro.Text = "Nombre";
            // 
            // lbPrecioLibro
            // 
            this.lbPrecioLibro.AutoSize = true;
            this.lbPrecioLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioLibro.Location = new System.Drawing.Point(133, 91);
            this.lbPrecioLibro.Name = "lbPrecioLibro";
            this.lbPrecioLibro.Size = new System.Drawing.Size(53, 16);
            this.lbPrecioLibro.TabIndex = 24;
            this.lbPrecioLibro.Text = "Precio";
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(458, 302);
            this.Controls.Add(this.lbPrecioLibro);
            this.Controls.Add(this.lbNombreLibro);
            this.Controls.Add(this.cmbCantidad);
            this.Controls.Add(this.checkBoxEfectivo);
            this.Controls.Add(this.lbImporte);
            this.Controls.Add(this.lblmporteAPagar);
            this.Controls.Add(this.lblCupon);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblLibro);
            this.Name = "FormVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVenta";
            this.Load += new System.EventHandler(this.FormVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCupon;
        private System.Windows.Forms.Label lblmporteAPagar;
        private System.Windows.Forms.Label lbImporte;
        private System.Windows.Forms.CheckBox checkBoxEfectivo;
        private System.Windows.Forms.ComboBox cmbCantidad;
        private System.Windows.Forms.Label lbNombreLibro;
        private System.Windows.Forms.Label lbPrecioLibro;
    }
}