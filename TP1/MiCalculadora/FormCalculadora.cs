﻿using System;
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

            lblResultado.Text = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)); 

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
            Numero numero = new Numero(lblResultado.Text);
            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
        }

        private void limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = " ";
            lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);              
            
            resultado = Calculadora.Operar(primerNumero, segundoNumero, operador);

            return resultado;
        }

    }
}
