using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

        }

        private void limpiar() {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
