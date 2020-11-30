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
using Excepciones;


namespace Solari.Rodolfo._2A.TP4
{
    public partial class FormFacturaCliente : Form
    {
        private Libreria libreria;
        Cliente cliente;
        public FormFacturaCliente()
        {
            InitializeComponent();
        }

        public FormFacturaCliente(Libreria libreria) : this()
        {
            this.libreria = libreria;
            this.cliente = new Cliente();
        }

        /// <summary>
        /// Realiza la compra generando la factura en formato texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompraTexto_Click(object sender, EventArgs e)
        {
            try
            {
                this.asignarDatosCliente();
                ArchivoTexto<Venta> ArchivoEscritura = new ArchivoTexto<Venta>();
                if (ArchivoEscritura.Guardar("Factura.txt", Factura.GenerarFactura(this.libreria, cliente)))
                {
                    MessageBox.Show("Se ha guardado la factura con exito");
                }
                else
                {
                    MessageBox.Show("Error al realizar la factura");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void FormFacturaCliente_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Realiza la compra generando la factura en formato xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompraXML_Click(object sender, EventArgs e)
        {
            try
            {
                this.asignarDatosCliente();

                SerializadorXml<Libreria> serializador = new SerializadorXml<Libreria>();
                if (serializador.Guardar("Factura.xml", this.libreria))
                {
                    MessageBox.Show("Se ha guardado la factura con exito");
                }
                else
                {
                    MessageBox.Show("Error al realizar la factura");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        public void asignarDatosCliente()
        {
            if(txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "")
            {
                throw new datosInvalidosException();
            }
            else
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.DNI = txtDni.Text;
            }
        }

    }
}
