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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (Numero.ValidarNumero(txtNumero1.Text) != 0 && Numero.ValidarNumero(txtNumero2.Text) != 0)
            {
                Numero primerNumero = new Numero(txtNumero1.Text);
                Numero segundoNumero = new Numero(txtNumero2.Text);
                string operador = cmbOperador.Text;
                if (operador != "")
                {
                    lblResultado.Text = Convert.ToString(Calculadora.Operar(primerNumero, segundoNumero, operador));
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un operador");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores validos");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(lblResultado.Text);
            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                Numero numero = new Numero(lblResultado.Text);
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            }
            else
            {
                lblResultado.Text = "Valor invalido";
            }
        }

        private void limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
