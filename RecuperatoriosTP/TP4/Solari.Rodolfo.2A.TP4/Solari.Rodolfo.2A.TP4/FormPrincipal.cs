using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solari.Rodolfo._2A.TP4
{
    public partial class FormPrincipal : Form
    {
        #region Atributos
        private List<Libro> libros;
        private Libreria libreria;
        private DataTable tablaLibros;
        private AccesoBaseDeDatos objAcceso;
        private Venta venta;
        private Thread hilo;

        public delegate void deshacerCambios();
        public event deshacerCambios limpiarCambios;

        #endregion
        #region Constructores
        public FormPrincipal()
        {
            InitializeComponent();
            this.limpiarCambios += this.limpiarVentas;
            this.objAcceso = new AccesoBaseDeDatos();
            this.libros = this.objAcceso.ObtenerListaLibros();
            this.tablaLibros = this.objAcceso.ObtenerTablaLibros();

            this.hilo = new Thread(this.mostrarImagenesIdiomas);
            this.hilo.Start();
            this.pictureBoxImagenes.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\francia.jpg";

            this.venta = new Venta();
            this.libreria = new Libreria();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// muestra las banderas de los idiomas, cambiandose constantemente
        /// </summary>
        public void mostrarImagenesIdiomas()
        {
            int i = 0;
            object[] arrayBanderas = new object[4];
            arrayBanderas[0] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\francia.jpg";
            arrayBanderas[1] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\alemania.jpg";
            arrayBanderas[2] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\estadosUnidos.jpg";
            arrayBanderas[3] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\brasil.png";

            while (true)
            {
                Thread.Sleep(2000);
                this.pictureBoxImagenes.ImageLocation = (string)arrayBanderas[i];

                if (i == arrayBanderas.Length-1)
                {
                    i = 0;
                }
                i++;
            }
        }


        /// <summary>
        /// limpia la venta realizada
        /// </summary>
        public void limpiarVentas()
        {
            richTextBoxFactura.Text = "";
            this.libreria.ListaVentas.Clear();
        }

        /// <summary>
        /// Carga la grilla con la base de datos Libros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLibros_Load(object sender, EventArgs e)
        {
            this.configurarGrilla(this.dataGridViewLibros);
            this.dataGridViewLibros.DataSource = this.tablaLibros;
        }

        /// <summary>
        /// Abre un nuevo formulario para agregar un nuevo libro a la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarNuevoLibro_Click(object sender, EventArgs e)
        {
            FormLibro formularioNuevoLibro = new FormLibro();
            if(formularioNuevoLibro.ShowDialog() == DialogResult.OK)
            {
                if (!this.objAcceso.InsertarLibro(formularioNuevoLibro.NuevoLibro))
                {
                    MessageBox.Show("Error al insertar un nuevo libro", "Error:", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    this.tablaLibros = this.objAcceso.ObtenerTablaLibros();
                }
            }        
        }

        /// <summary>
        /// configura la grilla que imprime la base de datos
        /// </summary>
        /// <param name="grilla"></param>
        private void configurarGrilla(DataGridView grilla)
        {
            grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            grilla.ColumnHeadersDefaultCellStyle.Font = new Font(grilla.Font, FontStyle.Italic);
            grilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.ReadOnly = false;
            grilla.MultiSelect = false;

            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            grilla.RowHeadersVisible = false;

        }

        /// <summary>
        /// abre el formulario de libro para eliminar el libro marcado en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewLibros.SelectedRows[0].Index;

                DataRow fila = this.tablaLibros.Rows[i];

                int id = int.Parse(fila["id"].ToString());

                FormLibro form = new FormLibro(this.objAcceso.ObtenerLibroPorId(id));

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (this.objAcceso.EliminarLibro(this.objAcceso.ObtenerLibroPorId(id)))
                    {
                        MessageBox.Show("Error", "Error al eliminar el libro", MessageBoxButtons.OK);
                        return;
                    }

                    this.tablaLibros.Rows[i].Delete();
                    this.tablaLibros.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Modifica el libro marcado en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewLibros.SelectedRows[0].Index;

                DataRow fila = this.tablaLibros.Rows[i];
                int id = int.Parse(fila["id"].ToString());

                Libro l = this.objAcceso.ObtenerLibroPorId(id);

                FormLibro form = new FormLibro(l);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (!this.objAcceso.ModificarLibro(form.NuevoLibro))
                    {
                        MessageBox.Show("Error", "Error al modificar el libro", MessageBoxButtons.OK);
                        return;
                    }

                }
                this.tablaLibros.Rows[i]["nombre"] = form.NuevoLibro.Nombre;
                this.tablaLibros.Rows[i]["cantidadPaginas"] = form.NuevoLibro.CantidadPaginas;
                this.tablaLibros.Rows[i]["idioma"] = form.NuevoLibro.Idioma;
                this.tablaLibros.Rows[i]["precio"] = form.NuevoLibro.Precio;
                this.tablaLibros.Rows[i]["stock"] = form.NuevoLibro.Stock;
                this.tablaLibros.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// Agrega al carrito el libro marcado en la tabla para realizar la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewLibros.SelectedRows[0].Index;
                DataRow fila = this.tablaLibros.Rows[i];

                int id = int.Parse(fila["id"].ToString());

                Libro libro = this.objAcceso.ObtenerLibroPorId(id);

                FormVenta form = new FormVenta(libro,this.venta);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.libreria.ListaVentas.Add(this.venta);
                    richTextBoxFactura.Text += this.venta.DevolverInformacionVenta(libro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// cierra el formulario principal y aborta el hilo de imagenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.hilo.Abort();
            this.Close();
        }

        /// <summary>
        /// Guarda la factura en un archivo texto y limpia la lista de ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormFacturaCliente form = new FormFacturaCliente(this.libreria);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.libreria.ListaVentas.Clear();
                }
                richTextBoxFactura.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// invoca el metodo limpiar Cambios para deshacer la venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCambios.Invoke();
        }
    }
}
