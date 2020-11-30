using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Solari.Rodolfo._2A.TP4
{
    public partial class FormVenta : Form
    {
        #region Atributos
        private Libro libroComprar;
        private Venta venta;
        private int cantidad;
        #endregion

        #region Constructor
        public FormVenta()
        {
            InitializeComponent();
        }

        public FormVenta(Libro libro, Venta venta) : this()
        {
            this.libroComprar = libro;
            this.venta = venta;
        }

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carga el formulario con los datos de los libros a comprar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVenta_Load(object sender, EventArgs e)
        {
            lbNombreLibro.Text = this.libroComprar.Nombre;
            lbPrecioLibro.Text = this.libroComprar.Precio.ToString();
            ActualizarImporte();
        }

        /// <summary>
        /// al cambiar el valor del cmbCantidad, se actualiza el importe a pagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarImporte();
        }

        /// <summary>
        /// actualiza el importe a pagar
        /// </summary>
        private void ActualizarImporte()
        {
            lbNombreLibro.Text = this.libroComprar.Nombre;
            lbPrecioLibro.Text = this.libroComprar.Precio.ToString();
            this.lbImporte.Text = (Convert.ToInt32(lbPrecioLibro.Text) * Convert.ToInt32(cmbCantidad.Text)).ToString();
        }

        /// <summary>
        /// Acepta la venta realizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.venta.Cantidad = Convert.ToInt32(cmbCantidad.Text);
                if (this.venta.Cantidad <= this.libroComprar.Stock) {
                    this.venta.Efectivo = checkBoxEfectivo.Checked;
                    this.venta.Vender(this.libroComprar, venta.Cantidad);
                    this.venta.Libro = this.libroComprar;
                }
                else
                {
                    MessageBox.Show("Error, ha ingresado una cantidad superior al stock actual del libro", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch(Exception)  // GENERAR EXCEPCION PROPIA

            {

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        #endregion

        /// <summary>
        /// Cierra el formulario cancelando la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
