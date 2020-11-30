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
    public partial class FormLibro : Form
    {
        #region Atributos
        private Libro libro;

        #endregion

        #region Propiedades
        public Libro NuevoLibro
        {
            get
            {
                return this.libro;
            }
        }
        #endregion

        #region Constructor
        public FormLibro()
        {
            InitializeComponent();
        }

        public FormLibro(Libro l) : this()
        {
            this.libro = l;
            this.txtNombre.Text = this.libro.Nombre;
            this.cmbIidiomas.Text = this.libro.Idioma;
            this.txtCantidadPaginas.Text = this.libro.CantidadPaginas.ToString();
            this.txtPrecio.Text = this.libro.Precio.ToString();
            this.txtStock.Text = this.libro.Stock.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        /// <summary>
        /// Segun el tipo de libro, genera el objeto segun lo que se necesite, ya se para eliminar o modifica el libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idLibro;
            if(this.libro != null)
            {
                idLibro = this.libro.ID;
            }
            else
            {
                idLibro = 0;
            }
            try
            {
                if (cmbTipo.Text == "Diccionario")
                {
                    this.libro = new Diccionario(idLibro, txtNombre.Text, int.Parse(txtCantidadPaginas.Text), cmbIidiomas.Text, float.Parse(txtPrecio.Text), int.Parse(txtStock.Text), cmbTipo.Text);
                }
                else
                {
                    this.libro = new Cuento(idLibro, txtNombre.Text, int.Parse(txtCantidadPaginas.Text), cmbIidiomas.Text, float.Parse(txtPrecio.Text), int.Parse(txtStock.Text), int.Parse(cmbTipo.Text));
                    
                }
            }
            catch(Exception)
            {
                
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// carga el formulario con botones no visibles, segun el tipo de libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLibro_Load(object sender, EventArgs e)
        {
            txtCantidadCapitulos.Visible = false;
            lbCapitulos.Visible = false;
            cmbTipoDiccionario.Visible = false;
            lbTipoDiccionario.Visible = false;
            actualizarTipo();
        }

        /// <summary>
        /// Segun el tipo de libro, se pondran visibles los labels y textos a utilizar
        /// </summary>
        private void actualizarTipo()
        {
            if(cmbTipo.Text == "Cuento")
            {
                txtCantidadCapitulos.Visible = true;
                lbCapitulos.Visible = true;
                cmbTipoDiccionario.Visible = false;
                lbTipoDiccionario.Visible = false;
            }
            else if(cmbTipo.Text == "Diccionario")
            {
                txtCantidadCapitulos.Visible = false;
                lbCapitulos.Visible = false;
                cmbTipoDiccionario.Visible = true;
                lbTipoDiccionario.Visible = true;
            }
        }

        /// <summary>
        /// actualiza el formulario con los respectivos textos y labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTipo();
        }
    }

}
