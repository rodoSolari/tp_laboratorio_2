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
                    this.dataGridViewLibros.DataSource = this.objAcceso.ObtenerTablaLibros();
                }
            }        
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
                Libro libro = this.objAcceso.ObtenerLibroPorId(id);

                DialogResult result = MessageBox.Show("¿Seguro desea eliminar el producto?\n" + libro.devolverInformacionLibro(), "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (!this.objAcceso.EliminarLibro(libro))
                    {
                        MessageBox.Show("Error", "Error al eliminar el libro", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        this.dataGridViewLibros.DataSource = this.objAcceso.ObtenerTablaLibros();
                    }
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

                Libro libro = this.objAcceso.ObtenerLibroPorId(id);

                FormLibro form = new FormLibro(libro);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (!this.objAcceso.ModificarLibro(form.NuevoLibro))
                    {
                        MessageBox.Show("Error al modificar el libro", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        this.dataGridViewLibros.DataSource = this.objAcceso.ObtenerTablaLibros();
                    }

                }
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

        /// <summary>
        /// configura la grilla que imprime la base de datos
        /// </summary>
        /// <param name="grilla"></param>
        private void configurarGrilla(DataGridView grilla)
        {
            // Coloco color de fondo para las filas
            this.dataGridViewLibros.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dataGridViewLibros.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;

            // Pongo color de fondo a la grilla
            this.dataGridViewLibros.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dataGridViewLibros.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewLibros.Font, FontStyle.Bold);
            this.dataGridViewLibros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dataGridViewLibros.GridColor = Color.Aqua;

            // La grilla será de sólo lectura
            this.dataGridViewLibros.ReadOnly = false;

            // No permito la multiselección
            this.dataGridViewLibros.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dataGridViewLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dataGridViewLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // No permito modificar desde la grilla
            this.dataGridViewLibros.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dataGridViewLibros.RowHeadersVisible = false;

        }
    }
}
