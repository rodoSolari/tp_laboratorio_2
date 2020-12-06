using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;


namespace Solari.Rodolfo._2A.TP4
{
    public partial class FormFacturaCliente : Form
    {
        #region Atributos
        private Libreria libreria;
        Cliente cliente;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor factura
        /// </summary>
        public FormFacturaCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor factura de cliente parametrizado
        /// </summary>
        /// <param name="libreria"></param>
        public FormFacturaCliente(Libreria libreria) : this()
        {
            this.libreria = libreria;
            this.cliente = new Cliente();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Realiza la compra generando la factura en formato texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompraTexto_Click(object sender, EventArgs e)
        {
            try
            {
                if (asignarDatosCliente())
                {
                    ArchivoTexto<Venta> ArchivoEscritura = new ArchivoTexto<Venta>();
                    if (ArchivoEscritura.Guardar("Factura "+this.cliente.Nombre+" "+this.cliente.Apellido+".txt", this.libreria.GenerarDatosFactura(this.cliente)))
                    {
                        MessageBox.Show("Se ha guardado la factura con exito");
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la factura");
                    }
                }
                else
                {
                    MessageBox.Show("Error, Por favor ingrese datos validos", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
            //this.Close();
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
                if (asignarDatosCliente())
                {

                    SerializadorXml<Libreria> serializador = new SerializadorXml<Libreria>();
                    if (serializador.Guardar("Factura "+this.cliente.Nombre+" "+this.cliente.Apellido+".xml", this.libreria))
                    {
                        MessageBox.Show("Se ha guardado la factura con exito");
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la factura");
                    }
                }
                else
                {
                    MessageBox.Show("Error, Por favor ingrese datos validos", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        /// <summary>
        /// Asigna los datos del cliente asignados en los campos del formulario si es que son validos, caso contrario devuelve false
        /// </summary>
        public bool asignarDatosCliente()
        {
            bool respuesta = false;
            if(!int.TryParse(txtDni.Text.ToString(),out int result) || string.IsNullOrWhiteSpace(txtDni.Text))
            {
                return false;
            }
            else if (!validarString(txtNombre.Text) || !validarString(txtApellido.Text))
            {
                return false;
            }
            else
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.DNI = txtDni.Text;
                respuesta = true;
            }
            return respuesta;
        }
        #endregion

        /// <summary>
        /// funcion para validar nombre y apellido ingresado del cliente
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private bool validarString(string dato)
        {
            bool respuesta = false;
            if (!string.IsNullOrWhiteSpace(dato) && Regex.IsMatch(dato, "^[a-zA-Z]"))
            {
                respuesta = true;
            }
            return respuesta;
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea cancelar la factura? La compra volvera a la tabla\n", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
