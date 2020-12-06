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
        public event deshacerCambios eventoLimpiarCambios;

        public delegate void cerrar();
        public event cerrar eventoSalir;

        #endregion
        #region Constructores
        public FormPrincipal()
        {
            InitializeComponent();
            //eventos
            this.eventoLimpiarCambios += this.limpiarVentas;
            this.eventoSalir += this.cerrarForm;

            //base de datos y tabla
            this.objAcceso = new AccesoBaseDeDatos();
            this.tablaLibros = this.objAcceso.ObtenerTablaLibros();

            //hilo
            this.hilo = new Thread(this.mostrarImagenesIdiomas);
            this.hilo.Start();
            this.pictureBoxImagenes.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\francia.jpg";

            //venta y libreria
            this.venta = new Venta();
            this.libreria = new Libreria();
        }
        #endregion


        /// <summary>
        /// muestra las banderas de los idiomas, cambiandose constantemente
        /// </summary>
        public void mostrarImagenesIdiomas()
        {
            int i = 0;
            object[] arrayBanderas = new object[5];
            arrayBanderas[0] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\francia.jpg";
            arrayBanderas[1] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\alemania.jpg";
            arrayBanderas[2] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\estadosUnidos.jpg";
            arrayBanderas[3] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\brasil.png";
            arrayBanderas[4] = AppDomain.CurrentDomain.BaseDirectory + @"\BanderasIdioma\italia.png";

            while (true)
            {
                Thread.Sleep(1000);
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
            richTextBoxFactura.Clear();
            this.tablaLibros.RejectChanges();
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
            try
            {
                FormLibro formularioNuevoLibro = new FormLibro();
                if (formularioNuevoLibro.ShowDialog() == DialogResult.OK)
                {
                    if (!this.objAcceso.InsertarLibro(formularioNuevoLibro.NuevoLibro))
                    {
                        MessageBox.Show("Error al insertar un nuevo libro", "Error:", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        this.tablaLibros = this.objAcceso.ObtenerTablaLibros();
                        this.dataGridViewLibros.DataSource = this.tablaLibros;
                    }
                }
            }
            catch(datosInvalidosException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Muestra un mensaje por pantalla mostrando lo datos del libro asignado y preguntando si lo desea eliminar
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
                        this.tablaLibros = this.objAcceso.ObtenerTablaLibros();
                        this.dataGridViewLibros.DataSource = this.tablaLibros;
                    }
                }
            }
            catch (EliminarException ex)
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
                        this.tablaLibros = this.objAcceso.ObtenerTablaLibros();
                        this.dataGridViewLibros.DataSource = this.tablaLibros;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Agrega al carrito el libro marcado en la tabla para realizar la compra y lo imprime en la richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewLibros.SelectedRows[0].Index;

                DataRow fila = this.tablaLibros.Rows[i];

                Libro libro = obtenerLibroTabla(fila);

                FormVenta form = new FormVenta(libro);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.libreria.ListaVentas.Add(form.Venta);
                    richTextBoxFactura.Text += form.Venta.DevolverInformacionVenta(libro);
                    this.tablaLibros.Rows[i]["stock"] = libro.Stock;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Devuelve el libro de la fila seleccionada de la tabla
        /// </summary>
        /// <param name="fila"></param>
        /// <returns></returns>
        private Libro obtenerLibroTabla(DataRow fila)
        {
            int id = int.Parse(fila["id"].ToString());
            string nombre = fila["nombre"].ToString();
            int cantidadPaginas = int.Parse(fila["cantidadPaginas"].ToString());
            string idioma = fila["idioma"].ToString();
            int precio = int.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());
            Libro libro;

            if (string.IsNullOrEmpty(fila["tipoDiccionario"].ToString()))
            {
                libro = new Cuento(id, nombre, cantidadPaginas, idioma, precio, stock, int.Parse(fila["cantidadCapitulos"].ToString()));
            }
            else
            {
                libro = new Diccionario(id, nombre, cantidadPaginas, idioma, precio, stock, fila["tipoDiccionario"].ToString());
            }

            return libro;
        }

        /// <summary>
        /// Abre el formulario para realizar la factura del cliente, al realizar la factura,
        /// se modifican los stocks de los libros comprados
        /// Si no se realiza la venta, se deshacen los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.libreria.ListaVentas.Count != 0)
            {
                try
                {
                    FormFacturaCliente form = new FormFacturaCliente(this.libreria);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Venta venta in this.libreria.ListaVentas)
                        {
                            // al realizar la factura, confirmo la venta y actualizo el stock de cada libro
                            this.objAcceso.ModificarLibro(venta.Libro);
                        }
                        this.tablaLibros.AcceptChanges();

                    }
                    else   //si cancela la compra, se reinicia
                    {
                        this.tablaLibros.RejectChanges();
                    }
                    this.libreria.ListaVentas.Clear();
                    richTextBoxFactura.Clear();
                }
                catch (Exception ex)
                {
                    this.tablaLibros.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay compras realizadas, debe agregar al carrito un libro para realizar la compra");
            }
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

        /// <summary>
        /// invoca el metodo limpiar Cambios para deshacer la venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.eventoLimpiarCambios.Invoke();
        }

        /// <summary>
        /// Cierra el formulario principal, y si hay una venta sin realizar la factura, se deshacen los cambios
        /// </summary>
        public void cerrarForm()
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir? Si tiene ventas sin realizar la compra volveran a la tabla\n", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.tablaLibros.RejectChanges();
                this.hilo.Abort();
                this.Close();
            }
        }

        /// <summary>
        /// cierra el formulario principal y aborta el hilo de imagenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.eventoSalir.Invoke();
        }

    }
}
