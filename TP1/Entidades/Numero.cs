using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributo
        private double numero;

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos

        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor invalido";
            int valorDecimal = 0;
            int posicionPotencia = 0;
            if (esBinario(binario))
            {
                for (int caracter = binario.Length - 1; caracter >= 0; caracter--)
                {
                    if (binario[caracter] == '1')
                    {
                        if (caracter == binario.Length - 1)
                        {
                            valorDecimal++;
                        }
                        else
                        {
                            valorDecimal += Convert.ToInt32(Math.Pow(2, posicionPotencia));
                        }
                    }
                    posicionPotencia++;
                }
                resultado = Convert.ToString(valorDecimal);
            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            return DecimalBinario(Convert.ToString(numero));
        }

        public string DecimalBinario(string numero)
        {
            string valorBinario = "Valor invalido";
            double valor = ValidarNumero(numero);
            if (valor != 0)
            {
                //Convierto el numero recibido en entero y devuelvo su valor absoluto
                valor = Math.Abs(Convert.ToDouble(numero));

                //Convierto el valor entero en string con base 2
                valorBinario = Convert.ToString(Convert.ToInt32(valor), 2);
            }
            return valorBinario;
        }

        public double ValidarNumero(string numero)
        {
            double numeroVerificado = 0;
            if (double.TryParse(numero, out numeroVerificado))
            {
                numeroVerificado = Convert.ToDouble(numero);
            }
            return numeroVerificado;

        }

        private static bool esBinario(string binario)
        {
            bool esBinario = false;
            for (int caracter = 0; caracter < binario.Length; caracter++)
            {
                if (binario[caracter] == '1' || binario[caracter] == '0')
                {
                    esBinario = true;
                }
                else
                {
                    esBinario = false;
                    break;
                }
            }
            return esBinario;
        }
        #endregion

        #region Sobrecarga de operadores

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;

            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;

            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;

            return resultado;
        }

        #endregion 
    }
}
